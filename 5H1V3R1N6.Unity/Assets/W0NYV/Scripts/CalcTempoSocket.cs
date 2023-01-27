using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

namespace W0NYV.Shivering
{
    public class CalcTempoSocket : MonoBehaviour
    {

        private Text _text;
        private CalcTempo _calcTempo;

        private float _bpm = 120.0f;
        public float BPM
        {
            get => _bpm;
        }

        private UnityEvent<float> _onCalculate = new UnityEvent<float>();
        public UnityEvent<float> OnCalculate { get => _onCalculate; }

        private void Awake() {
            _calcTempo = new CalcTempo();
            TryGetComponent<Text>(out _text);
        }

        public void DoCalcTempo(float v)
        {
            if(v == 1.0)
            {
                _calcTempo.Calculate();
                _bpm = _calcTempo.GetBPM();
                _text.text = "TEMPO: " + _bpm.ToString("0.00");
                _onCalculate.Invoke(_bpm);
            }
        }
    }
}
