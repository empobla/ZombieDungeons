/*
Script to spwn the key when all the enemies die 
Script to pickup the key

Alejandra Nissan Leizorek		

*/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetKey : MonoBehaviour
{
    //public Component doorCollider;

    // Start is called before the first frame update
    void Start()
    {
      
         
    }

    // Update is called once per frame
    void Update()
    {
        //variable to see if the level is complete or not
        gameObject.SetActive(false);
        Debug.Log("LevelComplete(): " + levelComplete());
        if (levelComplete()==true)
        {
            Debug.Log("levelComplete");
            gameObject.SetActive(true);
        }
    }
    //Method to pickup the key
    void OnTriggerEnter(Collider collider){

        if(collider.tag == "Player"){

            //KeyPicked variable manager
            if(PlayerPrefs.GetInt("KeyPicked",0)==2){
                PlayerPrefs.SetInt("KeyPicked",3);
            }

            if(PlayerPrefs.GetInt("KeyPicked",0)==1){
                PlayerPrefs.SetInt("KeyPicked",2);
            }
            if(PlayerPrefs.GetInt("KeyPicked",0)==0){
                PlayerPrefs.SetInt("KeyPicked",1);
            }
            Destroy(gameObject);
        }
    }

    bool levelComplete()
    {
        //nmethod to complete level
        //check the enemy count to see if is 0 and the complete the level
        bool complete = false;
        if (PlayerPrefs.GetInt("EnemyCount",-1) == -1)
        {
            Debug.Log("levelComplete(): No enemy count");
        }else if(PlayerPrefs.GetInt("EnemyCount",-1) == 0)
        {
            complete = true;//leverl complete 
        }else
        {

            complete = false;//if not there is more enemys to kill
        }
        
        return complete;
    }
}
