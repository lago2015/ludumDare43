using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusicManager : MonoBehaviour
{
    [SerializeField]
    [Header("Menu-Music")]
    public AudioSource BgMusicSource;
    
    [SerializeField]
    [Header("InGame-Music")]
    public AudioSource inGameMusicSrc;


    private void Start()
    {
        if(BgMusicSource)
        {
            InGameBackground();
        
        }
    }
    
    public void MenuBackground()
    {
        if (BgMusicSource != null)
        {
            if (inGameMusicSrc.isPlaying)
            {
                inGameMusicSrc.Stop();
            }
            BgMusicSource.priority = 200;
            BgMusicSource.minDistance = 1000f;
            BgMusicSource.loop = true;
            BgMusicSource.Play();
        }
    }

    public void InGameBackground()
    {
        if (inGameMusicSrc != null)
        {
            if(BgMusicSource.isPlaying)
            {
                BgMusicSource.Stop();
            }
            inGameMusicSrc.priority = 200;
            inGameMusicSrc.minDistance = 1000f;
            inGameMusicSrc.loop = true;
            inGameMusicSrc.Play();
        }
    }
    

}
