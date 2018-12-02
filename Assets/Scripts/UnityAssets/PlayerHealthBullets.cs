using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class PlayerHealthBullets : ScriptableObject {
    public int defaultAmount = 10;
    public int NumOfBullets;
    private int randNum;

    

    public void ReplenishBullets()
    {
        
        NumOfBullets = defaultAmount;
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
