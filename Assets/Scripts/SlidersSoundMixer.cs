using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SlidersSoundMixer : MonoBehaviour
{
    private readonly float _volumeConverterValue = 20;
    private readonly float _minVolumeValue = -80f;

    [SerializeField] private AudioMixer _audioMixer;
    [SerializeField] private Slider _slider;
    [SerializeField] private string _exposedParameters;

    private float _currentValue;

    private void OnEnable()
    {
        _slider.onValueChanged.AddListener(SetVolume);
    }

    private void OnDisable()
    {
        _slider.onValueChanged.RemoveListener(SetVolume);
    }

    private void SetVolume(float volume)
    {
        if (volume <= 0)
            _currentValue = _minVolumeValue;
        else
            _currentValue = Mathf.Log10(volume) * _volumeConverterValue;

        _audioMixer.SetFloat(_exposedParameters, _currentValue);

        //PlayerPrefs.SetFloat(_exposedParameters, _currentValue); - mozhno ispolzovatj dlja sohranenija pozicij slajderov i drugih parametrov
    }
}