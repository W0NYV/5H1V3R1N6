using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace W0NYV.Shivering.CubeCS
{
    [RequireComponent(typeof(GPUCubes))]
    public class CubesRender : MonoBehaviour
    {

        [SerializeField] private GPUCubes _gpuCubes;
        [SerializeField] private Mesh _instanceMesh;
        [SerializeField] private Material _instanceRenderMaterial;

        private uint[] args = new uint[5] { 0, 0, 0, 0, 0 };

        ComputeBuffer argsBuffer;

        private void RenderInstancedMesh()
        {
            if(_instanceRenderMaterial == null || _gpuCubes == null || !SystemInfo.supportsInstancing) return;

            uint numIndices = (_instanceMesh != null) ? (uint)_instanceMesh.GetIndexCount(0) : 0;

            args[0] = numIndices;

            args[1] = (uint)_gpuCubes.MaxObjectNum;

            argsBuffer.SetData(args);

            _instanceRenderMaterial.SetBuffer("_CubePositionBuffer", _gpuCubes.CubePositionBuffer);

            var bounds = new Bounds(Vector3.zero, new Vector3(32f, 32f, 32f));

            Graphics.DrawMeshInstancedIndirect(_instanceMesh, 0, _instanceRenderMaterial, bounds, argsBuffer);
        }

        #region MonoBehaviour Methods

        private void Start()
        {
            argsBuffer = new ComputeBuffer(1, args.Length * sizeof(uint), ComputeBufferType.IndirectArguments);
        }

        private void Update()
        {
            RenderInstancedMesh();
        }

        private void OnDisable() {
            if(argsBuffer != null) argsBuffer.Release();
            argsBuffer = null;
        }

        #endregion
    }
}
