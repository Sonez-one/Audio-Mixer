using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MuteToggle : MonoBehaviour
{
    private readonly float _muteValue = -80f;

    [SerializeField] private Toggle _toggle;
    [SerializeField] private AudioMixer _mixer;
    [SerializeField] private List<string> _exposedParameters;

    private float _currentVolume;

    public bool IsMuted { get; private set; }

    private void OnEnable()
    {
        _toggle.onValueChanged.AddListener(MuteSound);
    }

    private void OnDisable()
    {
        _toggle.onValueChanged.RemoveListener(MuteSound);
    }

    private void MuteSound(bool enabled)
    {
        foreach (var parameter in _exposedParameters)
        {
            _currentVolume = PlayerPrefs.GetFloat(parameter);

            if (enabled)
            {
                _mixer.SetFloat(parameter, _muteValue);

                IsMuted = true;
            }
            else
            {
                _mixer.SetFloat(parameter, _currentVolume);

                IsMuted = false;
            }
        }
    }
}