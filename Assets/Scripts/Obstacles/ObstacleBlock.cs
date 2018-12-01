using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleBlock : MonoBehaviour {

    

    private SpriteRenderer spriteComp;

    public float obstacleSpeed = 2;
    public string currentColor_text;
    private Vector3 position;
    private void Awake()
    {
        spriteComp = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        position = transform.position;
        position.x -= obstacleSpeed * Time.deltaTime;
        transform.position = position;
    }

    public void SwapInColor(int colorIndex)
    {
        
        switch (colorIndex)
        {
            //red
            case 0:
                currentColor_text = "Red";
                if(spriteComp)
                {
                    spriteComp.color = Color.red;
                }
                break;
            case 1:
                currentColor_text = "Blue";
                if (spriteComp)
                {
                    spriteComp.color = Color.blue;
                }

                break;
        }
        
    }

    public void AdjustSpeed(float newSpeed)
    {
        obstacleSpeed = newSpeed;
    }
}
