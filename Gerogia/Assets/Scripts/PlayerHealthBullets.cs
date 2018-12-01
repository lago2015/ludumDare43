using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class PlayerHealthBullets : ScriptableObject {

    public int NumOfBullets;
    private int randNum;

    

    public void ReplenishBullets()
    {
        randNum = Random.Range(4, 6);
        NumOfBullets = randNum;
    }

    public bool IsThereBulletsLeft()
    {
        if(NumOfBullets>0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void DecrementBullets()
    {
        NumOfBullets--;
    }
}
