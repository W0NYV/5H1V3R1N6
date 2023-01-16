using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;

namespace W0NYV.Shivering.CubeCS
{
    public class GPUCubes : MonoBehaviour
    {

        private int _threadSize = 3;
        private int _maxObjectNum = 9;
        public int MaxObjectNum
        {
            get => _maxObjectNum;
        }

        [SerializeField] private float _radius = 5f; 
        [SerializeField] private ComputeShader _cubesCS;

        private ComputeBuffer _cubePositionBuffer;
        public ComputeBuffer CubePositionBuffer
        {
            get => _cubePositionBuffer;
        }
        
        private void InitBuffer()
        {
            _cubePositionBuffer = new ComputeBuffer(_maxObjectNum, Marshal.SizeOf(typeof(Vector3)));

            var posArr = new Vector3[_maxObjectNum];
            for(int i = 0; i < _maxObjectNum; i++)
            {
                posArr[i] = Vector3.zero;
            }

            _cubePositionBuffer.SetData(posArr);

            posArr = null;
        }

        private void Simulation()
        {
            ComputeShader cs = _cubesCS;
            int id = -1;

            int threadGroupSize = Mathf.CeilToInt(_maxObjectNum / _threadSize);

            id = cs.FindKernel("RingCS");
            cs.SetFloat("_Radius", _radius);
            cs.SetInt("_CubeCount", _maxObjectNum);

            cs.SetBuffer(id, "_CubePositionBufferWrite", _cubePositionBuffer);

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
            if(_cubePositionBuffer != null)
            {
                _cubePositionBuffer.Release();
                _cubePositionBuffer = null;
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
