/*
Script to open de door of the Bunker 
Author Ale Nissan 
*/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyOpenBunker : MonoBehaviour
{
    public GameObject nextLevel2;
    public GameObject nextLevel3;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Check if level 1 is complete to allow access to level 2
        if(PlayerPrefs.GetInt("KeyPicked",0) == 1){
            Destroy(GameObject.Find ("Cube"));
            //Destroy(nextLevel2);
            Debug.Log("Se destruyó el objeto del cubo 2");
        }

        //Check if level 2 is complete to allow access to level 3
        if(PlayerPrefs.GetInt("KeyPicked",0) == 2){
            Destroy(GameObject.Find ("Cube 3"));
            Destroy(nextLevel2);
            Debug.Log("Se destruyó el objeto del cubo 3");
        }
    }

    
}
