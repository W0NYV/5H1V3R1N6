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

        private void Simulation()
        {
            ComputeShader cs = _quadsCS;
            int id = -1;

            int threadGroupSize = Mathf.CeilToInt(_maxObjectNum / _threadSize);

            id = cs.FindKernel("BoxCS");
            cs.SetInt("_QuadCount", _maxObjectNum);

            cs.SetBuffer(id, "_QuadDataBufferWrite", _quadDataBuffer);

            cs.Dispatch(id, threadGroupSize, 1, 1);

            // Vector3[] result = new Vector3[_maxObjectNum];
            // _cubePositionBuffer.GetData(result);

            // foreach (var pos in result)
            // {   
            //     Debug.Log(pos);
            // }

        }

        private void ReleaseBuffer()
        {
            if(_quadDataBuffer != null)
            {
                _quadDataBuffer.Release();
                _quadDataBuffer = null;
            }
        }

        #region MonoBehaviour Methods

        private void Start() {
            InitBuffer();
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
