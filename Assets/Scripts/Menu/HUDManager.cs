using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HUDManager : MonoBehaviour {

    public Text checkPointText;
    public Text scoreText;
    public TextMesh bulletText;
    public GameObject playerObj;
    public PlayerScore scoreAsset;
    private SpeedManager speedScript;
    public PlayerHealthBullets bulletAsset;
    private void Awake()
    {
        speedScript = FindObjectOfType<SpeedManager>();

        ResetScoreText();
    }

    public void AdjustBulletText()
    {
        bulletText.text = bulletAsset.NumOfBullets.ToString();
    }

    public void ResetScoreText()
    {
        speedScript.ResetSpeed();
        scoreAsset.ResetScore();
        scoreText.text = scoreAsset.GetCurrentScore().ToString();
        checkPointText.text = scoreAsset.GetCurrentCheckpoint().ToString();
    }

    public void IncrementScoreText(int value)
    {
        scoreAsset.IncrementScore(value);
        scoreText.text = scoreAsset.GetCurrentScore().ToString();
    }

    public void IncrementCheckPointText()
    {
        scoreAsset.IncrementCheckpoint();
        checkPointText.text = scoreAsset.GetCurrentCheckpoint().ToString();
        speedScript.CheckIfCanSpeedUp(scoreAsset.GetCurrentCheckpoint());
    }

    
	
}
