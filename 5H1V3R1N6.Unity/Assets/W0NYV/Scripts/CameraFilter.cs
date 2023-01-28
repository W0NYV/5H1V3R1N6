using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

namespace W0NYV.Shivering.PostEffect
{
    public class CameraFilter : MonoBehaviour
    {
        [SerializeField] private Material _filter;

        private bool _isXReverse = false;

        private void OnRenderImage(RenderTexture src, RenderTexture dest)
        {
            Graphics.Blit(src,dest,_filter);
        }

        private void Start() {
            GetComponent<Camera>().depthTextureMode |= DepthTextureMode.Depth;
        }

        public void BuildUp(float v)
        {
            if(v == 1.0)
            {
                _filter.EnableKeyword("_BUILD_UP");
            }
            else
            {
                _filter.DisableKeyword("_BUILD_UP");
            }
        }

        public void XReverse(float v)
        {
            if(v == 1.0)
            {
                _isXReverse = !_isXReverse;

                if(_isXReverse)
                {
                    _filter.EnableKeyword("_X_REVERSE");
                }
                else
                {
                    _filter.DisableKeyword("_X_REVERSE");
                }
            }
        }
    }
}