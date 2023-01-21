using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace W0NYV.Shivering.GPUQuads
{
    [RequireComponent(typeof(GPUQuads))]
    public class QuadsRenderer : MonoBehaviour
    {

        [SerializeField] private GPUQuads _gpuQuads;
        [SerializeField] private Mesh _instanceMesh;
        [SerializeField] private Material _instanceRenderMaterial;

        private uint[] args = new uint[5] { 0, 0, 0, 0, 0 };

        ComputeBuffer argsBuffer;

        private void RenderInstancedMesh()
        {
            if(_instanceRenderMaterial == null || _gpuQuads == null || !SystemInfo.supportsInstancing) return;

            uint numIndices = (_instanceMesh != null) ? (uint)_instanceMesh.GetIndexCount(0) : 0;

            args[0] = numIndices;

            args[1] = (uint)_gpuQuads.MaxObjectNum;

            argsBuffer.SetData(args);

            _instanceRenderMaterial.SetBuffer("_QuadDataBuffer", _gpuQuads.QuadDataBuffer);

            var bounds = new Bounds(Vector3.zero, new Vector3(128f, 128f, 128f));

            Graphics.DrawMeshInstancedIndirect(_instanceMesh, 0, _instanceRenderMaterial, bounds, argsBuffer);
        }

        #region public Methods

        public void SetOutlineIntensity(float v)
        {
            _instanceRenderMaterial.SetFloat("_OutlineIntensity", v);
        }

        public void SetInsideIntensity(float v)
        {
            _instanceRenderMaterial.SetFloat("_InsideIntensity", v);
        }

        public void ChangeToTextTex(float v)
        {
            if(v == 1.0)
            {
                _instanceRenderMaterial.EnableKeyword("_USE_TEXT_TEX");
                _instanceRenderMaterial.DisableKeyword("_USE_EYE_TEX");
            }
        }

        public void ChangeToEyeTex(float v)
        {
            if(v == 1.0)
            {
                _instanceRenderMaterial.EnableKeyword("_USE_EYE_TEX");
                _instanceRenderMaterial.DisableKeyword("_USE_TEXT_TEX");
            }
        }

        public void ChangeToFFTTex(float v)
        {
            if(v == 1.0)
            {
                _instanceRenderMaterial.DisableKeyword("_USE_EYE_TEX");
                _instanceRenderMaterial.DisableKeyword("_USE_TEXT_TEX");
            }
        }

        #endregion

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
