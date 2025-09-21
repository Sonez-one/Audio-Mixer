using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SliderController : MonoBehaviour
{
    private readonly float _volumeConverterValue = 20;

    [SerializeField] private AudioMixer _audioMixer;
    [SerializeField] private Slider _slider;
    [SerializeField] private string _exposedParameters;

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
        _audioMixer.SetFloat(_exposedParameters, Mathf.Log10(volume) * _volumeConverterValue);
    }
}