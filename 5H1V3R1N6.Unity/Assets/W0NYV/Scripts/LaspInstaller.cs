using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

namespace W0NYV.Shivering
{

    class DeviceItem : Dropdown.OptionData
    {
        public string id;
        public DeviceItem(in Lasp.DeviceDescriptor device)
            => (text, id) = (device.Name, device.ID);
    }

    public class LaspInstaller : MonoBehaviour
    {

        [SerializeField] private Dropdown _deviceList;
        private Lasp.SpectrumAnalyzer _spectrumAnalyzer;

        private Lasp.AudioLevelTracker _audioLevelTracker;
        [SerializeField] private CameraFilter _cameraFilter;

        [SerializeField] private RenderTexture _renderTex;

        [SerializeField] private Text _rangeGainText;
        private float _dynamicRange = 32;
        private float _gain = 20;

        [SerializeField] private Text _dThresholdRangeGainText;
        private float _dThresholdDynamicRange = 14;
        private float _dThresholdGain = -1.3f;

        private void Start()
        {

            _deviceList.onValueChanged.AddListener(val => OnDeviceSelected(val));

            _deviceList.ClearOptions();

            _deviceList.options.AddRange
                (Lasp.AudioSystem.InputDevices.Select(dev => new DeviceItem(dev)));
            
            _deviceList.RefreshShownValue();

            if(Lasp.AudioSystem.InputDevices.Any()) OnDeviceSelected(0);
        }
    

        public void OnDeviceSelected(int index)
        {
            Debug.Log(index);

            var id = ((DeviceItem)_deviceList.options[index]).id;
            var dev = Lasp.AudioSystem.GetInputDevice(id);

            if(_spectrumAnalyzer != null) Destroy(_spectrumAnalyzer.gameObject);

            var gameObject = new GameObject("Lasp KUN");

            _spectrumAnalyzer = gameObject.AddComponent<Lasp.SpectrumAnalyzer>();
            _spectrumAnalyzer.deviceID = dev.ID;
            _spectrumAnalyzer.resolution = 128;
            _spectrumAnalyzer.autoGain = false;
            _spectrumAnalyzer.gain = _gain;
            _spectrumAnalyzer.dynamicRange = _dynamicRange; 

            var spectrumAnalyzer = gameObject.AddComponent<Lasp.SpectrumToTexture>();
            spectrumAnalyzer.renderTexture = _renderTex;
            spectrumAnalyzer.overrideList = new Lasp.SpectrumToTexture.MaterialOverride[0];

            _audioLevelTracker = gameObject.AddComponent<Lasp.AudioLevelTracker>();
            _audioLevelTracker.deviceID = dev.ID;
            _audioLevelTracker.autoGain = false;
            _audioLevelTracker.gain = _dThresholdGain;
            _audioLevelTracker.dynamicRange = _dThresholdDynamicRange;
            _audioLevelTracker.propertyBinders =
                new [] {
                    new Lasp.FloatPropertyBinder {
                        Target = _cameraFilter,
                        PropertyName = "DThreshold",
                        Value0 = 0f,
                        Value1 = 1f
                    }
                };

        }

        public void ChangeDThresholdDynamicRange(float v)
        {
            _dThresholdDynamicRange = v * 39f + 1f;
            _audioLevelTracker.dynamicRange = _dThresholdDynamicRange;
            _dThresholdRangeGainText.text = "DThreshold:\n" + "Dynamic Range: " + _dThresholdDynamicRange.ToString("0.00") + "\n" + "Gain: " + _dThresholdGain.ToString("0.00");
        }

        public void ChangeDThresholdGain(float v)
        {
            _dThresholdGain = v * 50f - 10f;
            _audioLevelTracker.gain = _dThresholdGain;
            _dThresholdRangeGainText.text = "DThreshold:\n" + "Dynamic Range: " + _dThresholdDynamicRange.ToString("0.00") + "\n" + "Gain: " + _dThresholdGain.ToString("0.00");
        }

        public void ChangeDynamicRange(float v)
        {
            _dynamicRange = v * 119 + 1; 
            _spectrumAnalyzer.dynamicRange = _dynamicRange;
            _rangeGainText.text = "DynamicRange: " + _dynamicRange.ToString("0.00") + "\n" + "Gain: " + _gain.ToString("0.00");
        }

        public void ChangeGain(float v)
        {
            _gain = v * 130 - 10;
            _spectrumAnalyzer.gain = _gain;
            _rangeGainText.text = "DynamicRange: " + _dynamicRange.ToString("0.00") + "\n" + "Gain: " + _gain.ToString("0.00");
        }
    }
}
