using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SlidersSoundMixer : MonoBehaviour
{
    private readonly float _volumeConverterValue = 20;
    private readonly float _minVolumeValue = -80f;

    [SerializeField] private AudioMixer _audioMixer;
    [SerializeField] private Slider _slider;
    [SerializeField] private MuteToggle _muteToggle;
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
        _currentValue = Mathf.Log10(volume) * _volumeConverterValue;

        if (volume <= 0)
            _currentValue = _minVolumeValue;

        PlayerPrefs.SetFloat(_exposedParameters, _currentValue);

        if (_muteToggle.IsMuted == false)
            _audioMixer.SetFloat(_exposedParameters, _currentValue);
        else
            return;
    }
}