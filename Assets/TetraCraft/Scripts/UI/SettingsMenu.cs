using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using System;

public class SettingsMenu : MonoBehaviour
{
    [SerializeField] private AudioMixer _audioMixer;
    [SerializeField] private TMP_Dropdown _resolutionDropdown;


    private Resolution[] _resolutions;

    private void Start()
    {
        _resolutions = Screen.resolutions;

        _resolutionDropdown.ClearOptions();
        List<string> options = _resolutions
            .Select((r) => $"{r.width}x{r.height}").ToList();
        int indexOfCurrentResolution = Array.IndexOf(_resolutions, Screen.currentResolution);

        _resolutionDropdown.AddOptions(options);
        _resolutionDropdown.value = indexOfCurrentResolution;
        _resolutionDropdown.RefreshShownValue();
    }

    public void SetMusicVolume(float volume)
    {
        _audioMixer.SetFloat("MusicVolume", volume);
    }

    public void SetSoundFxVolume(float volume)
    {
        _audioMixer.SetFloat("SoundFxVolume", volume);
    }

    public void TogleFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }

    public void SetResolution(int indexOfResolution)
    {
        Resolution resolution = _resolutions[indexOfResolution];

        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
}
