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
    public GameObject gameOverScreen;

    public PlayerScore playerScore;
    public Text scoreText;
    public Text checkpointText;
    public Text highScoreText;
    public Text highCheckpointText;

    public Slider sfxSlider;
    public Slider musicSlider;

    public Image startButton;
    public Image titleImage;
    public Image ludumImage;
    public Sprite[] texts;
    public GameObject[] titles;

    private bool menuOn;
    private bool gameOver = false;
    private SoundManager soundManger;


    private void Start()
    {
        Menu();
        soundManger = FindObjectOfType<SoundManager>();
    }


    public void StartGame()
    {
        menuScreen.SetActive(false);
        gameOverScreen.SetActive(false);
        hud.SetActive(true);
        menuOn = false;
        gameOver = false;
        Time.timeScale = 1;
    }

    public void RestartGame()
    {
        // Logic for restarting scores, player, etc.

        StartGame();
    }

    public void Options()
    {
        optionScreen.SetActive(true);
    }

    public void HowToPlay()
    {
        howToPlaySceen.SetActive(true);
        gameOverScreen.SetActive(false);
    }

    public void Back()
    {
        optionScreen.SetActive(false);
        howToPlaySceen.SetActive(false);
        if (gameOver)
        {
            gameOverScreen.SetActive(true);
        }
    }

    public void Menu()
    {
        //ludumImage.enabled = true;
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
        ludumImage.enabled = false;

        startButton.sprite = texts[1];
    }

    public void GameOver()
    {
        ludumImage.enabled = true;

        gameOver = true;
        Menu();
        titles[0].SetActive(false);
        titles[1].SetActive(true);
        titles[2].SetActive(false);
        startButton.sprite = texts[2];
        gameOverScreen.SetActive(true);
        scoreText.text = playerScore.GetCurrentScore().ToString();
        checkpointText.text = playerScore.GetCurrentCheckpoint().ToString();

        if (playerScore.GetCurrentScore() > playerScore.GetHighScore())
        {
            playerScore.SetHighScore(playerScore.GetCurrentScore());
        }
        if (playerScore.GetCurrentCheckpoint() > playerScore.GetMostSacrificed())
        {
            playerScore.SetNewMostSacrificed(playerScore.GetCurrentCheckpoint());
        }

        highScoreText.text = playerScore.GetHighScore().ToString();
        highCheckpointText.text = playerScore.GetMostSacrificed().ToString();

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
