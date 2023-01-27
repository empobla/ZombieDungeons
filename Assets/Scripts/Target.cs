/*
Script to kill the zombies
Every bullet is -10 in health of the zombies
Isaac Garza
*/

using UnityEngine;
using UnityEngine.AI;

public class Target : MonoBehaviour
{
    public float enemyH = 50f;
    public int kills;
    public bool getKey;
    public GameObject key;
    BossAgent boss;
    float blockTime;
    public float time;
    public bool block;
    NavMeshAgent agent;
    

//Appear key after killing the enemies 
    void Start() 
    {
        getKey = false;
        agent = GetComponent<NavMeshAgent>();
        boss = GetComponent<BossAgent>();
        blockTime = 15f;
        block = false;

        
    }
    //method to kill the enemies every time they recieve damage
    public void TakeDamage(float amount)
    {
        if (gameObject.name != "monster_orc")
        {
            enemyH -= amount;
        }else if (block)
        {
           
        }else
        {
            enemyH -= amount;
        }
        
        if ((enemyH <= 1000f) && (gameObject.name == "monster_orc"))
        {
            agent.speed = 5f;
            
        }

        if ((enemyH <= 0f) && (gameObject.name != "monster_orc"))
        {
            Die();
            
        }else if(enemyH <= 0f)
        {
            DieBoss();
        }
    }


    void Update()
    {
        time+=Time.deltaTime;
        if (time > blockTime+10f)
        {
           time = 0;
           block = false;
        }else if (time > blockTime)
        {
            block = true;
        }
    }
//Appear key after killing all the enemies 
    void Die()
    {
        
        if (PlayerPrefs.GetInt("EnemyCount",-1) == -1)
        {
            Debug.Log("Die(): No enemy count");
            
        }else if(PlayerPrefs.GetInt("EnemyCount",-1) > 0)
        {
            PlayerPrefs.SetInt("EnemyCount",PlayerPrefs.GetInt("EnemyCount",-1)-1);
            Debug.Log("Enemy count =" + PlayerPrefs.GetInt("EnemyCount",-1));
            if (PlayerPrefs.GetInt("EnemyCount",-1) == 0)
            {
                key.SetActive(true);
            }
        }else
        {

        }

        Destroy(gameObject);
    }

    void DieBoss()
    {
        boss.EnemyDeathAnim();
         if (PlayerPrefs.GetInt("EnemyCount",-1) == -1)
        {
            Debug.Log("Die(): No enemy count");
            
        }else if(PlayerPrefs.GetInt("EnemyCount",-1) > 0)
        {
            PlayerPrefs.SetInt("EnemyCount",PlayerPrefs.GetInt("EnemyCount",-1)-1);
            Debug.Log("Enemy count =" + PlayerPrefs.GetInt("EnemyCount",-1));
            if (PlayerPrefs.GetInt("EnemyCount",-1) == 0)
            {
                Instantiate(key,new Vector3(1.16f,1.71f,22.41835f),Quaternion.identity);
            }
        }else
        {

        }

        Destroy(gameObject,10);
    }
        
       
}
