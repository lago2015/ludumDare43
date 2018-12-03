using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class PlayerScore : ScriptableObject {

    public int currentScore;
    public int currentCheckpoint;
    private int highScore;

    public void IncrementCheckpoint()
    {
        currentCheckpoint++;
    }

    public int GetCurrentCheckpoint()
    {
        return currentCheckpoint;
    }

    public void IncrementScore(int value)
    {
        currentScore += value;
    }

    public void ResetScore()
    {
        currentScore = 0;
        currentCheckpoint = 0;
    }

    public int GetCurrentScore()
    {
        return currentScore;
    }

    public int GetHighScore()
    {
        highScore = PlayerPrefs.GetInt("highScore");
        return highScore;
    }

    public int GetMostSacrificed()
    {
        return PlayerPrefs.GetInt("mostSacrificed");
    }

    public int SetHighScore(int newHighScore)
    {
        PlayerPrefs.SetInt("highScore", newHighScore);
        return newHighScore;
    }


    public int SetNewMostSacrificed(int newSacrifice)
    {
        PlayerPrefs.SetInt("mostSacrificed", newSacrifice);
        return newSacrifice;
    }
}
