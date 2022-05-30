using UnityEngine;
using UnityEngine.Audio;

public class SettingsMenu : MonoBehaviour
{
    [SerializeField] private AudioMixer _audioMixer;

    public void SetMusicVolume(float volume)
    {
        _audioMixer.SetFloat("MusicVolume", volume);
    }

    public void SetSoundFxVolume(float volume)
    {
        _audioMixer.SetFloat("SoundFxVolume", volume);
    }
}
