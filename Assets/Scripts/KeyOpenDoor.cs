/*
Script to pick up the key and open door 	
Alejandra Nissan Leizorek		

*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KeyOpenDoor : MonoBehaviour
{
   // private float timer = 0.0f;
    public int time;
    bool near;
    

    // Start is called before the first frame update
    void Start()
    {
        near = false;

    }

    // Update is called once per frame
    void Update()
    {
        //check if the player can open the door 
        if(near && PlayerPrefs.GetInt("KeyPicked",0) == 1 && SceneManager.GetActiveScene().name =="Level1"){
            Debug.Log("Abriste la puerta");
            Debug.Log(PlayerPrefs.GetInt("KeyPicked",0));
            Destroy(gameObject);
            
        }

         if(near && PlayerPrefs.GetInt("KeyPicked",0) == 2 && SceneManager.GetActiveScene().name =="Level2"){
            Debug.Log("Level 2 complete");
            Destroy(gameObject);
            
        }
           if(near && PlayerPrefs.GetInt("KeyPicked",0) == 3){
            Debug.Log("Game Complete");
            SceneManager.LoadScene("Final Scene");
            
        }
        
    }

    //Player touches the key and pick up 
    void OnTriggerEnter(Collider collider){
        if(collider.tag == "Player"){
            near = true;
        }
    }

    void OnTriggerExit(Collider collider){
        if(collider.tag == "Player"){
            near = false;
        }
    }

}
