using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public struct Sound
{
    public string name;
    public AudioClip clip;
};

public class SoundManager : MonoBehaviour
{
    // Audio sources for sound effects and music
    public AudioSource effects;
    public AudioSource music;

    // Array of sounds to use
    public Sound[] sounds;

    // Dictionary to hold reference to all the sounds
    private Dictionary<string, AudioClip> soundList;

    private void Start()
    {
        soundList = new Dictionary<string, AudioClip>();

        foreach (Sound sound in sounds)
        {
            soundList.Add(sound.name, sound.clip);
        }
    }

    public void PlaySound(string clip)
    {
        effects.clip = soundList[clip];
        effects.Play();
    }

    public void PlayMusic(string clip)
    {
        music.clip = soundList[clip];
        music.Play();
    }

    public void SetSFXVolume(float val)
    {
        effects.volume = val;
    }

    public void SetMusicVolume(float val)
    {
        music.volume = val;
    }
}
