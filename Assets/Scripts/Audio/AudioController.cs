using UnityEngine;
using System.Collections;

public class AudioController : MonoBehaviour {
    // Singleton instance 
    [SerializeField]
    public static AudioController instance;

    [SerializeField]
    [Header("Player Death")]
    public AudioSource playerDeathSource;
    public float hitDelay;
    public float maxHitDelay;
    [SerializeField]
    [Header("Player Shoot")]
    public AudioSource playerShootSrc;
    public float absorbDelay = 0.5f;
    [Header("BulletPop")]
    public AudioSource bulletPopSrc;
    [SerializeField]
    [Header("Wall Destruction")]
    public AudioSource wallDestructionSrc;
    public float deathDelay = 0.5f;
    [SerializeField]
    [Header("CheckPointObtain")]
    public AudioSource checkPointObtained;
    public float dash1Delay = 0.5f;
    [SerializeField]
    [Header("SpikeEnemy")]
    public AudioSource SpikeEnemySrc;
    public float HealthUpDelay = 0.5f;

    
    
    // Use this for initialization
    void Start () {
        instance = this;
	}
    public void PlayerDeath(Vector3 pos)
    {
        if (playerDeathSource != null)
        {
            playerDeathSource.pitch = Random.Range(0.8f, 1f);
            playerDeathSource.volume = Random.Range(0.8f, 1f);
            
            playerDeathSource.loop = false;
            playerDeathSource.Play();
        }
    }

    public void PlayerShot(Vector3 pos)
    {
        if (playerShootSrc != null)
        {
            
            playerShootSrc.volume = 0.5f;
            playerShootSrc.loop = false;
            playerShootSrc.Play();

         
        }
    }

    public void PlutoDash1(Vector3 pos)
    {
        if (checkPointObtained != null)
        {
            checkPointObtained.transform.position = pos;

            checkPointObtained.loop = false;
            checkPointObtained.Play();

         
        }
    }



    public void PlutoDeath(Vector3 pos)
    {
        if (wallDestructionSrc != null)
        {

            wallDestructionSrc.transform.position = pos;
            wallDestructionSrc.loop = false;
            wallDestructionSrc.Play();
        }
    }


    public void PlutoHealthUp(Vector3 pos)
    {
        if (SpikeEnemySrc != null)
        {
            SpikeEnemySrc.transform.position = pos;
            SpikeEnemySrc.loop = false;
            SpikeEnemySrc.Play();
        }
    }
    public void BulletPop(Vector3 pos)
    {
        if (bulletPopSrc != null)
        {
            if(bulletPopSrc.isPlaying)
            {
                bulletPopSrc.Stop();
            }
            bulletPopSrc.transform.position = pos;
            bulletPopSrc.loop = false;
            bulletPopSrc.Play();
        }
    }
    
}
