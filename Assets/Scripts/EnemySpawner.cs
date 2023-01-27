/*
Script to spawn the enemies in the scene
The spwn will spawn the enemies near xthe player 

Isaac Garza Strimlingas		
Alejandra Nissan Leizorek		
Jorge Damián Palacios Hristova	

*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject theEnemy;
    Player player;
    Vector3 positionPlayer;
    public float xpos;
    public float zpos;
    public int enemycount;
    public int enemyCap;
    float x;
    float z;
    public int xMin;
    public int xMax;
    public int zMin;
    public int zMax;

    //get the position of thenplayer as a reference 
    void Start()
    {  
      StartCoroutine(EnemyDrop());
      player = GameObject.FindWithTag("Player").GetComponent<Player>();
      positionPlayer = player.transform.position;  
    }

    // Update is called once per frame
    void Update()
    {
        //positionPlayer = player.transform.position * Time.deltaTime;  
        //x = positionPlayer.x * Time.deltaTime;
        //z = positionPlayer.z * Time.deltaTime;
    }

    //Method to drop enemys in the scene in a specific range
    public IEnumerator EnemyDrop()
    {
        PlayerPrefs.SetInt("EnemyCount",1);
        while (enemycount<enemyCap)
        {
            xpos = Random.Range(xMin, xMax);
            zpos = Random.Range(zMin,zMax);
            Instantiate(theEnemy,new Vector3(xpos, 0 ,zpos),Quaternion.identity);
            yield return new WaitForSeconds(0);//the enemy already in the scene 
            enemycount += 1;//count the enemies so the key can spawn 

        }

        //Count of the enemies 
        PlayerPrefs.SetInt("EnemyCount",enemycount+1);
        Debug.Log("Enemy count =" + PlayerPrefs.GetInt("EnemyCount",-1));
        

       
    }
}
