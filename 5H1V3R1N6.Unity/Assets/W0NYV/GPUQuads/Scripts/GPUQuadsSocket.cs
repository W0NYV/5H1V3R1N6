using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace W0NYV.Shivering.GPUQuads
{
    [RequireComponent(typeof(GPUQuads))]
    public class GPUQuadsSocket : MonoBehaviour
    {
        private GPUQuads _gpuQuads;

        private void Awake() {
            TryGetComponent<GPUQuads>(out _gpuQuads);
        }

        #region ChangeMode
        public void ChangeOneBoxMode(float v)
        {
            if(v == 1.0)
            {
                _gpuQuads.ChangeMode(0);
            }
        }

        public void ChangeTiledBoxMode(float v)
        {
            if(v == 1.0)
            {
                _gpuQuads.ChangeMode(1);
            }
        }

        public void ChangeLineMode(float v)
        {
            if(v == 1.0)
            {
                _gpuQuads.ChangeMode(2);
            }
        }

        public void ChangeTileMode(float v)
        {
            if(v == 1.0)
            {
                _gpuQuads.ChangeMode(3);
            }
        }

        public void ChangeSphereMode(float v)
        {
            if(v == 1.0)
            {
                _gpuQuads.ChangeMode(4);
            }
        }

        #endregion
    
        public void BuildUp(float v)
        {
            _gpuQuads.TimeSpeed = 1.0f + 19.0f*v;
        }

        public void DoAccelerate(float v)
        {
            if(v == 1.0) _gpuQuads.CanAccelerate = true;
        }
    
    }
}
