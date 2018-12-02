using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResetGameobjects : MonoBehaviour {

    private PlayerShooting shootScript;
    private ObstacleManager obstacleManagerScript;
    private HUDManager hudScript;
    private MenuManager menuScript;
    private ObjectPoolManager poolManager;
    private GameObject checkPoint;
    public TextMesh playerBulletText;
    private Vector3 startPosition;
    
    private GameObject playerObject;
    private void Awake()
    {
        playerObject= GameObject.FindGameObjectWithTag("Player");
        startPosition = playerObject.transform.position;
        shootScript = playerObject.GetComponent<PlayerShooting>();
        hudScript = FindObjectOfType<HUDManager>();
        obstacleManagerScript = FindObjectOfType<ObstacleManager>();
        menuScript = FindObjectOfType<MenuManager>();
        poolManager = FindObjectOfType<ObjectPoolManager>();
    }

    public void TurnOffText()
    {
        playerBulletText.gameObject.SetActive(false);

    }

    public void GameOverReset()
    {
        //Reset player settings
        playerObject.transform.position = startPosition;
        shootScript.PlayerStatus(true);
        
        //look for any lingering checkpoints
        checkPoint = GameObject.FindGameObjectWithTag("PickUp");
        if(checkPoint)
        {
            Destroy(checkPoint);
            checkPoint = GameObject.FindGameObjectWithTag("PickUp");
            if(checkPoint)
            {
                Destroy(checkPoint);
            }
        }
        //reset score
        hudScript.ResetScoreText();

        //stop obstacle Spawning
        obstacleManagerScript.StopEnums();
        
        //reset pools
        poolManager.ReturnAllObject("blockPool");
        poolManager.ReturnAllObject("explosionPool");
        poolManager.ReturnAllObject("bulletPool");

        //turns off hud and turns on game over screen
        menuScript.GameOver();
    }

    public void NewGame()
    {
        obstacleManagerScript.NewGameObstacles();
        hudScript.ResetScoreText();
        shootScript.PlayerStatus(false);
        playerBulletText.gameObject.SetActive(true);
        //turns off menu and turns on hud
        menuScript.StartGame();


    }

}
