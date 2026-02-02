using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AudioID
{
    MainBgm,
    BubbleSfx,
    GoatSfx,
}


public class AudioManager : MonoBehaviour
{
    private static AudioManager instance;
    [SerializeField] private AudioSource bgmSource;
    [SerializeField] private AudioSource sfxSource;

    [Tooltip("MainBgm,\r\n    BubbleSfx,\r\n    GoatSfx,")]
    [SerializeField] private AudioClip[] audioList;

    private void Awake()
    {
        instance = this;
    }

    public static void PlayBGM(AudioID audioId, float volume = 1)
    {
        instance.bgmSource.clip = instance.audioList[(int)audioId];
        instance.bgmSource.loop = true;
        instance.bgmSource.volume = volume;
        instance.bgmSource.Play();
    }
    public static void PlaySFX(AudioID audioId, float volume=1)
    {
        instance.sfxSource.PlayOneShot(instance.audioList[(int)audioId],  volume);
    }
}
