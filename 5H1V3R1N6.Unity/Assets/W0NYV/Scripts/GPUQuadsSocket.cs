using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//GPUQuadsを外部入力によっていじる
namespace W0NYV.Shivering.GPUQuads
{
    [RequireComponent(typeof(GPUQuads))]
    public class GPUQuadsSocket : MonoBehaviour
    {
        [SerializeField] CalcTempoSocket _calcTempoSocket;
        private GPUQuads _gpuQuads;

        private bool _canUseTime = false;

        private void Awake() {
            TryGetComponent<GPUQuads>(out _gpuQuads);

            _calcTempoSocket.OnCalculate.AddListener(bpm => _gpuQuads.BPM = bpm);
        }

        #region ChangeMode

        public void ChangeOneBoxMode(float v){if(v == 1.0) _gpuQuads.ChangeMode(0);}
        public void ChangeTiledBoxMode(float v){if(v == 1.0) _gpuQuads.ChangeMode(1);}
        public void ChangeLineMode(float v){if(v == 1.0) _gpuQuads.ChangeMode(2);}
        public void ChangeTileMode(float v){if(v == 1.0) _gpuQuads.ChangeMode(3);}
        public void ChangeSphereMode(float v){if(v == 1.0) _gpuQuads.ChangeMode(4);}
        public void ChangeTunnelMode(float v){if(v == 1.0) _gpuQuads.ChangeMode(5);}
        public void ChangeLissajousMode(float v){if(v == 1.0) _gpuQuads.ChangeMode(6);}

        #endregion

        public void ChangeActionValue(float v)
        {
            _gpuQuads.ActionValue = v;
        }

        public void ChangeLerpSpeed(float v)
        {
            _gpuQuads.LerpSpeed = v * 2.95f + 0.05f;
        }

        public void BuildUp(float v)
        {
            _gpuQuads.TimeSpeed = 1f + 19.0f*v;            
        }

        public void SwitchAccelerate(float v)
        {
            if(v == 1.0) _gpuQuads.CanAccelerate = !_gpuQuads.CanAccelerate;
        }
    
    }
}
