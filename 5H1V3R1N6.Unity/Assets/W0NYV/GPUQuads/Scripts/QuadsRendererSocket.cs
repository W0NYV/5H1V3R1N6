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

        public void TextTex(float v) {if(v == 1.0) _quadsRenderer.SwitchTex(0);}
        public void EyeTex(float v) {if(v == 1.0) _quadsRenderer.SwitchTex(1);}
        public void FFTTex(float v) {if(v == 1.0) _quadsRenderer.SwitchTex(2);}
        public void SingleTex(float v) {if(v == 1.0) _quadsRenderer.SwitchTex(3);}
        public void VColorTex(float v) {if(v == 1.0) _quadsRenderer.SwitchTex(4);}

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
