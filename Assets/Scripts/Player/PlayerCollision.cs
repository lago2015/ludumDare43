using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour {

    private MenuManager menuScript;
    private Collider2D myCollider;
    public ObjectPoolManager pillarDodgedPool;
    public string colliderPoolString="colliderPool";
    private PlayerShooting playerShootScript;
    private PlayerMovement playerMoveScript;
    public PlayerHealthBullets healthAsset;
    private ResetGameobjects resetScript;
    private ObstacleManager obstacleScipt;
    public GameObject explosion;
    private SpriteRenderer spriteComp;
    private int pillarsDodged;
    private Vector3 startPosition;
    private void Awake()
    {
        startPosition = transform.position;
        menuScript = FindObjectOfType<MenuManager>();
        myCollider = GetComponent<Collider2D>();
        spriteComp = GetComponent<SpriteRenderer>();
        playerMoveScript = GetComponent<PlayerMovement>();
        playerShootScript = GetComponent<PlayerShooting>();
        obstacleScipt = FindObjectOfType<ObstacleManager>();
        resetScript = FindObjectOfType<ResetGameobjects>();
    }

    private void Start()
    {
        ResetGame();
    }

    public void ResetGame()
    {
        healthAsset.ReplenishBullets();
        explosion.SetActive(false);
        spriteComp.enabled = true;
        myCollider.enabled = true;
        Time.timeScale = 1;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        ObstacleBlock curObstacle = col.gameObject.GetComponent<ObstacleBlock>();
        if(curObstacle && col.CompareTag("Obstacle"))
        {
            GameOver();
        }
        else if(col.CompareTag("Obstacle"))
        {
            BloodinatorCollision bloodinatorScript = col.gameObject.GetComponent<BloodinatorCollision>();
            if(bloodinatorScript)
            {
                GameOver();
            }
        }
    }

    void GameOver()
    {
        //enable explosion and disable sprite
        explosion.SetActive(true);
        spriteComp.enabled = false;
        myCollider.enabled = false;
        resetScript.TurnOffText();
        StartCoroutine(DelayGameOver());
    }

    IEnumerator DelayGameOver()
    {
        yield return new WaitForSeconds(1f);
        resetScript.GameOverReset();
        ResetGame();
    }
    
}
