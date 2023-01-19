using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace W0NYV.Shivering.PostEffect
{
    public class CameraFilter : MonoBehaviour
    {
        [SerializeField] private Material filter;

        private void OnRenderImage(RenderTexture src, RenderTexture dest)
        {
            Graphics.Blit(src,dest,filter);
        }
    }
}
