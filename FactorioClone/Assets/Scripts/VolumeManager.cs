using UnityEngine;
using UnityEngine.Audio;

public class VolumeManager : MonoBehaviour
{
    public AudioMixer audioMixer; // Reference to your AudioMixer

    private void Start()
    {
        // Load saved volume settings when the Options Menu loads
        float masterVolume = PlayerPrefs.GetFloat("MasterVolume", 1f); // Default to 1
        float sfxVolume = PlayerPrefs.GetFloat("SFXVolume", 1f); // Default to 1
        float musicVolume = PlayerPrefs.GetFloat("MusicVolume", 1f); // Default to 1

        SetMasterVolume(masterVolume);
        SetSFXVolume(sfxVolume);
        SetMusicVolume(musicVolume);
    }

    public void SetMasterVolume(float volume)
    {
        audioMixer.SetFloat("MasterVolume", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("MasterVolume", volume); // Save volume setting
        PlayerPrefs.Save();
    }

    public void SetSFXVolume(float volume)
    {
        audioMixer.SetFloat("SFXVolume", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("SFXVolume", volume); // Save volume setting
        PlayerPrefs.Save();
    }

    public void SetMusicVolume(float volume)
    {
        audioMixer.SetFloat("MusicVolume", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("MusicVolume", volume); // Save volume setting
        PlayerPrefs.Save();
    }
}
