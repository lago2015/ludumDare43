using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public GameObject menuScreen;
    public GameObject optionScreen;
    public GameObject howToPlaySceen;
    public GameObject hud;
    public GameObject controls;
  

    public Slider sfxSlider;
    public Slider musicSlider;

    public Image startButton;
    public Image titleImage;

    public Sprite[] texts;
    public GameObject[] titles;

    private bool menuOn;
    private SoundManager soundManger;


    private void Start()
    {
        Menu();
        soundManger = FindObjectOfType<SoundManager>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            if (!menuOn)
            {
                GameOver();
            }
        }
    }

    public void StartGame()
    {
        menuScreen.SetActive(false);
        controls.SetActive(false);
        hud.SetActive(true);
        menuOn = false;
        FindObjectOfType<Parallaxing>().StartStop(true);
        Time.timeScale = 1;
    }

    public void RestartGame()
    {
        // Logic for restarting scores, player, etc.

        StartGame();
    }

    public void Options()
    {
        sfxSlider.value = soundManger.effects.volume;
        musicSlider.value = soundManger.music.volume;
        optionScreen.SetActive(true);
    }

    public void HowToPlay()
    {
        howToPlaySceen.SetActive(true);
    }

    public void Back()
    {
        optionScreen.SetActive(false);
        howToPlaySceen.SetActive(false);
    }

    public void Menu()
    {
        menuScreen.SetActive(true);
        optionScreen.SetActive(false);
        howToPlaySceen.SetActive(false);
        titles[0].SetActive(true);
        titles[1].SetActive(false);
        titles[2].SetActive(false);
        hud.SetActive(false);
        menuOn = true;
        Time.timeScale = 0;
    }

    public void Pause()
    {
        Menu();
        titles[0].SetActive(false);
        titles[1].SetActive(false);
        titles[2].SetActive(true);
        startButton.sprite = texts[1];
    }

    public void GameOver()
    {
        Menu();
        titles[0].SetActive(false);
        titles[1].SetActive(true);
        titles[2].SetActive(false);
        startButton.sprite = texts[2];
        FindObjectOfType<Parallaxing>().StartStop(false);
        Time.timeScale = 0;
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
