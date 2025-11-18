using System.Runtime.Serialization;
using UnityEngine;
using UnityEngine.Audio;


public class SoundMixerManager : MonoBehaviour
{
    [SerializeField] GameObject soundPanel;

    [SerializeField] private AudioMixer audioMixer;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            soundPanel.SetActive(!soundPanel.activeSelf);
        }
    }


    public void SetMasterVolume(float level)
    {
        audioMixer.SetFloat("masterVolume", level);
    }
    public void SetSFXVolume(float level)
    {
        audioMixer.SetFloat("sfxVolume", level);

    }
    public void SetMusicVolume(float level)
    {
        audioMixer.SetFloat("musicVolume", level);
    }
    
}

