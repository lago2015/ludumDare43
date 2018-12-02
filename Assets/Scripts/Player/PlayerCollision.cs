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
    public GameObject explosion;
    private SpriteRenderer spriteComp;
    private bool isDead;
    private int pillarsDodged;
    public bool isPlayerDead() { return isDead; }

    private void Awake()
    {
        menuScript = FindObjectOfType<MenuManager>();
        myCollider = GetComponent<Collider2D>();
        spriteComp = GetComponent<SpriteRenderer>();
        playerMoveScript = GetComponent<PlayerMovement>();
        playerShootScript = GetComponent<PlayerShooting>();
        
    }

    private void Start()
    {
        ResetGame();
    }

    public void ResetGame()
    {
        playerMoveScript.PlayerStatus(false);
        playerShootScript.PlayerStatus(false);
        explosion.SetActive(false);
        spriteComp.enabled = true;
        myCollider.enabled = true;
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
        playerMoveScript.PlayerStatus(true);
        playerShootScript.PlayerStatus(true);
        explosion.SetActive(true);
        spriteComp.enabled = false;
        myCollider.enabled = false;
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
