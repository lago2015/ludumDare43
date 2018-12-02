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
    private ObstacleManager obstacleScipt;
    public GameObject explosion;
    private SpriteRenderer spriteComp;
    private bool isDead;
    private int pillarsDodged;
    public bool isPlayerDead() { return isDead; }
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
    }

    private void Start()
    {
        ResetGame();
    }

    public void ResetGame()
    {
        healthAsset.ReplenishBullets();
        transform.position = startPosition;
        playerMoveScript.PlayerStatus(false);
        playerShootScript.PlayerStatus(false);
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
        
    }

    void GameOver()
    {
        //tell player scripts that player is dead
        playerMoveScript.PlayerStatus(true);
        playerShootScript.PlayerStatus(true);
        //enable explosion and disable sprite
        explosion.SetActive(true);
        spriteComp.enabled = false;
        myCollider.enabled = false;


        StartCoroutine(DelayGameOver());
        
        
    }

    IEnumerator DelayGameOver()
    {
        yield return new WaitForSeconds(0.5f);

        //reset pools
        pillarDodgedPool.ReturnAllObject("blockPool");
        pillarDodgedPool.ReturnAllObject("explosionPool");
        pillarDodgedPool.ReturnAllObject("bulletPool");
        //stop obstacle manager from spawning
        obstacleScipt.StopEnums();
        obstacleScipt.NewGameObstacles();

        menuScript.GameOver();
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if(col.CompareTag("PillarDodged"))
        {
            pillarDodgedPool.PutBackObject(colliderPoolString, col.gameObject);
            pillarsDodged++;
        }
    }
}
