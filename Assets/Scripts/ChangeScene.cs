/*
Script to change the scene when the player 
has finished the level and takes the key
	
Jorge Damián Palacios Hristova	
*/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    bool near;
    public string Scene;
    
    // Start is called before the first frame update
    void Start()
    {
        near = false;

    }

    // Update is called once per frame
    void Update()
    {
        //Load scene 
        if(near)
        {
         SceneManager.LoadScene(Scene);
        }
    }

    //when the player takes the key and go through the door
    void OnTriggerEnter(Collider collider){
        if(collider.tag == "Player"){
            near = true;
        }

    }

    //if the player is not touching the door is not activated 
    void OnTriggerExit(Collider collider){
        if(collider.tag == "Player"){
            near = false;
        }
    }
}
