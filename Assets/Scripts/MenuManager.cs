using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public GameObject menuScreen;
    public GameObject optionScreen;

    public Slider sfxSlider;
    public Slider musicSlider;

    public Text startText;
    public Text titleText;

    private bool menuOn;
    private SoundManager soundManger;

    private void Start()
    {
        Menu();
        soundManger = FindObjectOfType<SoundManager>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            if(!menuOn)
            {
                Pause();
            }
        }
    }

    public void StartGame()
    {
        menuScreen.SetActive(false);
        menuOn = false;
        Time.timeScale = 1;
    }

    public void Options()
    {
        sfxSlider.value = soundManger.effects.volume;
        musicSlider.value = soundManger.music.volume;
        optionScreen.SetActive(true);
    }

    public void Back()
    {
        optionScreen.SetActive(false);
    }

    public void Menu()
    {
        menuScreen.SetActive(true);
        optionScreen.SetActive(false);
        menuOn = true;
        Time.timeScale = 0;
    }

    public void Pause()
    {
        Menu();
        startText.text = "Resume";
    }

    public void GameOver()
    {
        Menu();
        titleText.text = "Game Over";
        startText.text = "Restart";
    }
    
    public void QuitGame()
    {
        Application.Quit();
    }

    public void setVolume(bool sfx)
    {
        if (sfx)
        {
            soundManger.SetSFXVolume(sfxSlider.value);
        }
        else
        {
            soundManger.SetMusicVolume(musicSlider.value);
        }
    }
}
