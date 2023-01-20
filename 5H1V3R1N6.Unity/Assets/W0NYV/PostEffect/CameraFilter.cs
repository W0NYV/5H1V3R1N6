using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace W0NYV.Shivering.PostEffect
{
    public class CameraFilter : MonoBehaviour
    {
        [SerializeField] private Material _filter;

        private void OnRenderImage(RenderTexture src, RenderTexture dest)
        {
            Graphics.Blit(src,dest,_filter);
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
    }
}
