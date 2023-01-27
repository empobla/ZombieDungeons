/******************************************
Script for manage the health bar of the main 
character and the zombies.
Jorge Damián Palacios Hristova	
*******************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    public int maxHealth = 100;
    public int currentHealth;
    public HealthBar healthBar;

    // Start is called before the first frame update
    //the health is start at 100 for the object 
    void Start()
    {
        currentHealth = PlayerPrefs.GetInt("Health",maxHealth);
        healthBar.SetMax(maxHealth, currentHealth);

    }

    // Update is called once per frame
    // Method when the player take damage 

    //Method to update damage 
    public void DamageTaken (int damage)
    {
        currentHealth-=damage;
        healthBar.SetHealth(currentHealth);
        PlayerPrefs.SetInt("Health",currentHealth);
    }
    //Method to take damage from the zombies when they touch the player
    void OnCollisionEnter(Collision col) 
    {
     if (col.gameObject.CompareTag("Zombie"))
     {
         DamageTaken(5);//damage taken 
     }     
    }

    void OnTriggerEnter(Collider col) 
    {
     if (col.gameObject.CompareTag("Boss"))
     {
         DamageTaken(15);//damage taken 
     }   
    }

    //load losescene when player looses 
    void gameOver()
    {
        SceneManager.LoadScene("LoseScene");
    }

    //checks the health of the player if his health is 0 game over scene is presented
    void Update()
    {
        if (PlayerPrefs.GetInt("Health", 0) <= 0)
        {
            gameOver();
        }
    }

    
}
