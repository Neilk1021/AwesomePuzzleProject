using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class AudioData
{
    public string name;
    public AudioClip clip;
}


public class AudioManager : MonoBehaviour
{
    private static AudioManager instance;
    [SerializeField] private AudioSource bgmSource;
    [SerializeField] private AudioSource sfxSource;

    [SerializeField] private AudioData[] audioDatas;

    private Dictionary<string, AudioClip> clipDict;

    private void Awake()
    {
        instance = this;
        BuildAudioDictionary();
    }

    private void BuildAudioDictionary()
    {
        clipDict = new Dictionary<string, AudioClip> ();
        foreach (var data in audioDatas)
        {
            clipDict[data.name] = data.clip;
        }
    }

    public static void PlayBGM(string name, float volume = 1, bool loop=true)
    {
        instance.bgmSource.clip = instance.clipDict[name];

        if (loop)
            instance.bgmSource.loop = true;
        else
            instance.bgmSource.loop = false;
        
        instance.bgmSource.volume = volume;
        instance.bgmSource.Play();
    }
    public static void PlaySFX(string name, float volume=1)
    {
        instance.sfxSource.PlayOneShot(instance.clipDict[name],  volume);
    }
}
