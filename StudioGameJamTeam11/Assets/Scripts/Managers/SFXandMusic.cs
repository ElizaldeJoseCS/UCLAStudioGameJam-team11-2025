using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public struct SFXEntry
{
    public string name;             // Name used to call the SFX
    public AudioClip clip;          // The audio file
    public float volume;            // Default volume (0–1)
}
public class SFXandMusic : MonoBehaviour
{
    public static SFXandMusic instance;

    [Header("Audio Sources")]
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioSource sfxSourcePrefab;

    [Header("SFX List")]
    [SerializeField] private List<SFXEntry> sfxList;

    private Dictionary<string, AudioClip> sfxLookup;

    private void Awake()
    {
        if (instance == null)
            instance = this;

        // Build quick-lookup dictionary
        sfxLookup = new Dictionary<string, AudioClip>();
        foreach (var entry in sfxList)
            if (!sfxLookup.ContainsKey(entry.name))
                sfxLookup.Add(entry.name, entry.clip);
    }

    // -------------------------
    //      MUSIC
    // -------------------------
    public void PlayMusic(AudioClip clip, float volume = 1f)
    {
        musicSource.clip = clip;
        musicSource.volume = volume;
        musicSource.Play();
    }

    public void StopMusic()
    {
        musicSource.Stop();
    }

    // -------------------------
    //         SFX
    // -------------------------
    public void PlaySFX(string name, Vector3 position, float volume = 1f)
    {
        if (!sfxLookup.TryGetValue(name, out AudioClip clip))
        {
            Debug.LogWarning($"SFX '{name}' not found!");
            return;
        }

        AudioSource audioSource = Instantiate(sfxSourcePrefab, position, Quaternion.identity);
        audioSource.volume = volume;
        audioSource.clip = clip;
        audioSource.Play();

        Destroy(audioSource.gameObject, clip.length + 0.1f);
    }
    public void PlayPartialSFX(string name, Vector3 position, float duration, float volume = 1f)
{
    if (!sfxLookup.TryGetValue(name, out AudioClip clip))
    {
        Debug.LogWarning($"SFX '{name}' not found!");
        return;
    }

    AudioSource audioSource = Instantiate(sfxSourcePrefab, position, Quaternion.identity);
    audioSource.volume = volume;
    audioSource.clip = clip;
    audioSource.Play();

    // Stop early
    Destroy(audioSource.gameObject, duration);  // duration < clip.length
}
}
