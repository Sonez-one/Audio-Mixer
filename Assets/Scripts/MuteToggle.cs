using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MuteToggle : MonoBehaviour
{
    private readonly float _muteValue = -80f;

    [SerializeField] private Toggle _toggle;
    [SerializeField] private AudioMixer _mixer;

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
            _mixer.SetFloat("Master", _muteValue);
        else
            _mixer.SetFloat("Master", 0);
    }
}