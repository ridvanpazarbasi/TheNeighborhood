using System;
using System.Collections.Generic;
using UnityEngine;

public class SoundsManager : MonoBehaviour
{
    public static SoundsManager Instance;
    public List<SoundsData> sounds;
    public AudioSource audioSource;

    private void Awake() => Instance = this;


    public void SoundPlay(SoundsType type,bool isLoop=false)
    {
        foreach (var sound in sounds)
        {
            if (sound.sound == type)
            {
                
                    audioSource.loop = isLoop;
                
                audioSource.clip = sound.audioClip;
                audioSource.Play();
            }
        }
    }
}

public enum SoundsType
{
    Combing,
    HandGun,
    Kill,
    Magazine,
    MagnumGun,
    PumpGun
}

[Serializable]
public class SoundsData
{
    public SoundsType sound;
    public AudioClip audioClip;
}