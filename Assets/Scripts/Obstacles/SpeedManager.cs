using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedManager : MonoBehaviour {

    public float setDefaultSpeed;
    private float curSpeed;
    public float incrementRate = 0.2f;
    public int curSpeedPref;
    public int speedCap = 10;
    private ObstacleManager obstacleScript;
//    private ResetGameobjects resetScript;
    private void Awake()
    {
  //      resetScript = GameObject.FindGameObjectWithTag("MainMenu").GetComponent<ResetGameobjects>();
        obstacleScript = GameObject.FindGameObjectWithTag("Respawn").GetComponent<ObstacleManager>();
        ResetSpeed();
    }

    public void ResetSpeed()
    {
        curSpeed = setDefaultSpeed;
        obstacleScript.TurnOnFastMode(false);
    }

    public void AdjustSpeed(bool isEnabled)
    {
        if(isEnabled)
        {
            ResetSpeed();
        }
        else
        {
            curSpeed = 0;
        }
        //resetScript.AdjustBackgroundSpeeds(curSpeed);
        CheckMode();
    }

    public float GetSpeed()
    {
        return curSpeed;
    }
    //called from main menu script after X score is achieved
    public void IncrementSpeed()
    {
        //if speed if below the set cap then increment speed
        if(curSpeed<=speedCap)
        {
            curSpeed += incrementRate;
        }
        CheckMode();
    }

    void CheckMode()
    {
        //this adjusts color generation to keep up with the speed
        if (curSpeed >= 6)
        {
            obstacleScript.TurnOnFastMode(true);
        }
        else
        {
            obstacleScript.TurnOnFastMode(false);
        }
    }

}
