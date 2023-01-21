using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;

namespace W0NYV.Shivering.GPUQuads
{

    public class GPUQuads : MonoBehaviour
    {

        [System.Serializable] struct QuadData
        {
            public Vector3 position;
            public Vector3 rotation;
            public Vector3 scale;
            public float index;
        }

        private int _threadSize = 4;
        [SerializeField] private int _maxObjectNum = 128;
        public int MaxObjectNum
        {
            get => _maxObjectNum;
        }

        [SerializeField] private int _modeNum = 0;
        [SerializeField] private int _preModeNum = 0;

        [SerializeField] private ComputeShader _quadsCS;

        private ComputeBuffer _quadDataBuffer;
        public ComputeBuffer QuadDataBuffer
        {
            get => _quadDataBuffer;
        }

        [SerializeField] private float _lerpValue = 1f;
        [SerializeField] private float _lerpSpeed = 1f;
        [SerializeField] private float _timeSpeed = 1f;
        
        [SerializeField] private bool canAccelerate = false;
        float accelerateTime = 0f;

        private void InitBuffer()
        {
            _quadDataBuffer = new ComputeBuffer(_maxObjectNum, Marshal.SizeOf(typeof(QuadData)));

            var quadDataArr = new QuadData[_maxObjectNum];
            for(int i = 0; i < _maxObjectNum; i++)
            {
                quadDataArr[i].position = Vector3.zero;
                quadDataArr[i].rotation = Vector3.zero;
                quadDataArr[i].scale = new Vector3(1f, 1f, 1f);
                quadDataArr[i].index = 0f;
            }

            _quadDataBuffer.SetData(quadDataArr);

            quadDataArr = null;
        }

        private void ChangeMode(int modeNum)
        {
            _modeNum = modeNum;
            _lerpValue = 0f;
        }

        private float Fract(float t)
        {
            return t - Mathf.Floor(t);
        }

        private float Accelerate()
        {
            if(canAccelerate)
            {
                accelerateTime += Time.deltaTime * 3.0f;

                float t = (0.05f/Fract(accelerateTime)-0.05f)*3f;

                if(1f <= accelerateTime)
                {
                    canAccelerate = false;
                }

                return t;
            }
            else
            {
                accelerateTime = 0f;
                return 0f;
            }
        }

        private void Simulation()
        {

            // if(Input.GetKeyDown("r")) ChangeMode(0);
            // if(Input.GetKeyDown("t")) ChangeMode(1);
            // if(Input.GetKeyDown("y")) ChangeMode(2);
            // if(Input.GetKeyDown("u")) ChangeMode(3);
            // if(Input.GetKeyDown("i")) ChangeMode(4);

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
            cs.SetFloat("_Time", Time.time * _timeSpeed - Accelerate());

            cs.SetBuffer(id, "_QuadDataBufferWrite", _quadDataBuffer);

            cs.Dispatch(id, threadGroupSize, 1, 1);
        }

        private void ReleaseBuffer()
        {
            if(_quadDataBuffer != null)
            {
                _quadDataBuffer.Release();
                _quadDataBuffer = null;
            }
        }

        #region public Methods

        public void ChangeOneBoxMode(float v)
        {
            if(v == 1.0)
            {
                ChangeMode(0);
            }
        }

        public void ChangeLoopBoxMode(float v)
        {
            if(v == 1.0)
            {
                ChangeMode(1);
            }
        }

        public void ChangeLineMode(float v)
        {
            if(v == 1.0)
            {
                ChangeMode(2);
            }
        }

        public void ChangeTileMode(float v)
        {
            if(v == 1.0)
            {
                ChangeMode(3);
            }
        }

        public void ChangeSphereMode(float v)
        {
            if(v == 1.0)
            {
                ChangeMode(4);
            }
        }

        public void BuildUp(float v)
        {
            _timeSpeed = 1.0f + 19.0f*v;
        }

        public void DoAccelerate(float v)
        {
            canAccelerate = true;
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
