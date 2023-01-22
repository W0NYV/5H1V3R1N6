using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace W0NYV.Shivering.GPUQuads
{
    [RequireComponent(typeof(QuadsRenderer))]
    public class QuadsRendererSocket : MonoBehaviour
    {

        private QuadsRenderer _quadsRenderer;

        private void Awake() {
            TryGetComponent<QuadsRenderer>(out _quadsRenderer);
        }

        #region Outline

        public void SetOutlineIntensity(float v)
        {
            _quadsRenderer.InstanceRenderMaterial.SetFloat("_OutlineIntensity", v);
        }

        public void ChangeOutlineWidth(float v)
        {
            float value = v * 0.007f + 0.003f;
            _quadsRenderer.InstanceRenderMaterial.SetFloat("_OutlineWidth", value);
        }

        #endregion

        #region Texture

        public void ChangeToTextTex(float v)
        {
            if(v == 1.0)
            {
                _quadsRenderer.InstanceRenderMaterial.EnableKeyword("_USE_TEXT_TEX");
                _quadsRenderer.InstanceRenderMaterial.DisableKeyword("_USE_EYE_TEX");
            }
        }

        public void ChangeToEyeTex(float v)
        {
            if(v == 1.0)
            {
                _quadsRenderer.InstanceRenderMaterial.EnableKeyword("_USE_EYE_TEX");
                _quadsRenderer.InstanceRenderMaterial.DisableKeyword("_USE_TEXT_TEX");
            }
        }

        public void ChangeToFFTTex(float v)
        {
            if(v == 1.0)
            {
                _quadsRenderer.InstanceRenderMaterial.DisableKeyword("_USE_EYE_TEX");
                _quadsRenderer.InstanceRenderMaterial.DisableKeyword("_USE_TEXT_TEX");
            }
        }

        #endregion

        public void SetInsideIntensity(float v)
        {
            _quadsRenderer.InstanceRenderMaterial.SetFloat("_InsideIntensity", v);
        }

        public void ReverseFFTEmission(float v)
        {
            if(v == 1.0)
            {
                _quadsRenderer.IsFFTEmissionMode = !_quadsRenderer.IsFFTEmissionMode;
                
                if(_quadsRenderer.IsFFTEmissionMode)
                {
                    _quadsRenderer.InstanceRenderMaterial.EnableKeyword("_USE_FFT_AMPLITUDE");
                }
                else
                {
                    _quadsRenderer.InstanceRenderMaterial.DisableKeyword("_USE_FFT_AMPLITUDE");
                }
            }
        }

    }
}
