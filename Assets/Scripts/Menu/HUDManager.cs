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
    public PlayerHealthBullets bulletAsset;
    private void Awake()
    {
        ResetScoreText();
    }

    public void AdjustBulletText()
    {
        bulletText.text = bulletAsset.NumOfBullets.ToString();
    }

    public void ResetScoreText()
    {
        scoreAsset.ResetScore();
        scoreText.text = scoreAsset.GetCurrentScore().ToString();
        checkPointText.text = "Checkpoint: " + scoreAsset.GetCurrentCheckpoint();
    }

    public void IncrementScoreText(int value)
    {
        scoreAsset.IncrementScore(value);
        scoreText.text = scoreAsset.GetCurrentScore().ToString();
    }

    public void IncrementCheckPointText()
    {
        scoreAsset.IncrementCheckpoint();
        checkPointText.text = "Checkpoint: " + scoreAsset.GetCurrentCheckpoint();
    }
	
}
