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
        public Material InstanceRenderMaterial { get => _instanceRenderMaterial; }

        private string[] _shaderKeywords = {
            "_USE_TEXT_TEX",
            "_USE_EYE_TEX",
            "_USE_FFT_TEX",
            "_USE_SINGLE_TEX",
            "_USE_WAVE_TEX",
            "_USE_YMG_TEX"
        };

        private uint[] args = new uint[5] { 0, 0, 0, 0, 0 };

        // private ComputeBuffer argsBuffer;
        private GraphicsBuffer _g_ArgsBuffer;

        private bool _isFFTEmissionMode = false;
        public bool IsFFTEmissionMode
        {
            get => _isFFTEmissionMode;
            set => _isFFTEmissionMode = value;
        }

        public void SwitchTex(int index)
        {
            _instanceRenderMaterial.EnableKeyword(_shaderKeywords[index]);

            int i = 0;
            foreach (string keyword in _shaderKeywords)
            {   
                if(i != index) _instanceRenderMaterial.DisableKeyword(keyword);
                i++;
            }
        }

        private void RenderInstancedMesh()
        {
            if(_instanceRenderMaterial == null || _gpuQuads == null || !SystemInfo.supportsInstancing) return;

            uint numIndices = (_instanceMesh != null) ? (uint)_instanceMesh.GetIndexCount(0) : 0;

            args[0] = numIndices;

            args[1] = (uint)_gpuQuads.MaxObjectNum;

            // argsBuffer.SetData(args);
            _g_ArgsBuffer.SetData(args);

            _instanceRenderMaterial.SetBuffer("_QuadDataBuffer", _gpuQuads.QuadDataBuffer);

            var bounds = new Bounds(Vector3.zero, new Vector3(128f, 128f, 128f));

            Graphics.DrawMeshInstancedIndirect(_instanceMesh, 0, _instanceRenderMaterial, bounds, _g_ArgsBuffer);
        }

        #region MonoBehaviour Methods

        private void Start()
        {
            // argsBuffer = new ComputeBuffer(1, args.Length * sizeof(uint), ComputeBufferType.IndirectArguments);
            _g_ArgsBuffer = new GraphicsBuffer(GraphicsBuffer.Target.IndirectArguments, 1, args.Length * sizeof(uint));
        }

        private void Update()
        {
            RenderInstancedMesh();
        }

        private void OnDisable() {
            if(_g_ArgsBuffer != null) _g_ArgsBuffer.Release();
            _g_ArgsBuffer = null;
        }

        #endregion
    }
}
