using UnityEngine;
using UnityEngine.UI;

public class MuteToggle : MonoBehaviour
{
    private readonly int _audioListenerMinVolume = 0;
    private readonly int _audioListenerMaxVolume = 1;

    [SerializeField] private Toggle _toggle;

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
        if (enabled)
            AudioListener.volume = _audioListenerMinVolume;
        else
            AudioListener.volume = _audioListenerMaxVolume;

        //Mozhno takze cherez  AudioListener.pause.
    }
}