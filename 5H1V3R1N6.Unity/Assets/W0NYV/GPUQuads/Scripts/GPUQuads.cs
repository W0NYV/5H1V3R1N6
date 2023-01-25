using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;

namespace W0NYV.Shivering.GPUQuads
{

    public class GPUQuads : MonoBehaviour
    {
        #region 必須
        [System.Serializable] struct QuadData
        {
            public Vector3 position;
            public Vector3 rotation;
            public Vector3 scale;
        }

        private int _threadSize = 4;
        [SerializeField] private int _maxObjectNum = 128;
        public int MaxObjectNum
        {
            get => _maxObjectNum;
        }

        [SerializeField] private ComputeShader _quadsCS;

        private ComputeBuffer _quadDataBuffer;
        public ComputeBuffer QuadDataBuffer
        {
            get => _quadDataBuffer;
        }
        #endregion
        
        #region ChangeMode
        [SerializeField] private int _modeNum = 0;
        [SerializeField] private int _preModeNum = 0;
        [SerializeField] private float _lerpValue = 1f;
        [SerializeField] private float _lerpSpeed = 1f;
        #endregion

        [SerializeField] private float _timeSpeed = 1f;
        public float TimeSpeed
        {
            get => _timeSpeed;
            set => _timeSpeed = value;
        }

        private float _bpm = 120.0f;
        public float BPM
        {
            set => _bpm = value;
        }

        [SerializeField] private bool _canAccelerate = false;
        public bool CanAccelerate
        {
            get => _canAccelerate;
            set => _canAccelerate = value;
        }

        private float _scaleX = 1f;
        public float ScaleX
        {
            get => _scaleX;
            set => _scaleX = value;
        }

        public void ChangeMode(int modeNum)
        {
            _modeNum = modeNum;
            _lerpValue = 0f;
        }

        private float Fract(float t)
        {
            return t - Mathf.Floor(t);
        }

        // private float Accelerate()
        // {
        //     if(_canAccelerate)
        //     {
        //         accelerateTime += Time.deltaTime * 3.0f;

        //         float t = (0.05f/Fract(accelerateTime)-0.05f)*3f;

        //         if(1f <= accelerateTime)
        //         {
        //             _canAccelerate = false;
        //         }

        //         return t;
        //     }
        //     else
        //     {
        //         accelerateTime = 0f;
        //         return 0f;
        //     }
        // }

        private void Simulation()
        {

            // if(Input.GetKeyDown("r")) ChangeMode(0);
            // if(Input.GetKeyDown("t")) ChangeMode(1);
            // if(Input.GetKeyDown("y")) ChangeMode(2);
            // if(Input.GetKeyDown("u")) ChangeMode(3);
            // if(Input.GetKeyDown("i")) ChangeMode(4);

            float time = (Time.time*_bpm/60.0f) * _timeSpeed;

            ComputeShader cs = _quadsCS;
            int id = -1;
            
            if(_lerpValue<1f) 
            {
                _lerpValue += Time.deltaTime * _lerpSpeed;
            }
            else
            {
                _lerpValue = 1f;
                _preModeNum = _modeNum;
            }

            int threadGroupSize = Mathf.CeilToInt(_maxObjectNum / _threadSize);

            id = cs.FindKernel("TransformCS");
            cs.SetInt("_QuadCount", _maxObjectNum);
            cs.SetInt("_ModeNum", _modeNum);
            cs.SetInt("_PreModeNum", _preModeNum);
            cs.SetFloat("_LerpValue", _lerpValue);

            if(_canAccelerate) 
            {
                cs.SetFloat("_Time", time - (0.05f/Fract(time)-0.05f)*5f);
            }
            else
            {
                cs.SetFloat("_Time", Time.time * _timeSpeed);
            }            

            cs.SetFloat("_ScaleX", _scaleX);

            cs.SetBuffer(id, "_QuadDataBufferWrite", _quadDataBuffer);

            cs.Dispatch(id, threadGroupSize, 1, 1);
        }

        #region Buffer関連

        private void InitBuffer()
        {
            _quadDataBuffer = new ComputeBuffer(_maxObjectNum, Marshal.SizeOf(typeof(QuadData)));

            var quadDataArr = new QuadData[_maxObjectNum];
            for(int i = 0; i < _maxObjectNum; i++)
            {
                quadDataArr[i].position = Vector3.zero;
                quadDataArr[i].rotation = Vector3.zero;
                quadDataArr[i].scale = new Vector3(1f, 1f, 1f);
            }

            _quadDataBuffer.SetData(quadDataArr);

            quadDataArr = null;
        }

        private void ReleaseBuffer()
        {
            if(_quadDataBuffer != null)
            {
                _quadDataBuffer.Release();
                _quadDataBuffer = null;
            }
        }

        #endregion

        #region MonoBehaviour Methods

        private void Start() {
            InitBuffer();
            _preModeNum = _modeNum;
        }

        private void Update() {
            Simulation();
        }

        private void OnDestroy() {
            ReleaseBuffer();
        }

        #endregion
    }
}
