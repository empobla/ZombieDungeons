/*
Script for the health bar of the main character 
and the zombies.
	
Jorge Damián Palacios Hristova	
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    public Slider slider;
    public Gradient gradiente;
    public Image fill;

//Method to set max value of health according to the player 
//start the gradient in the max value so it changes color later
    public void SetMax(int maxHealth, int currentHealth)
    {
        slider.maxValue = maxHealth;
        slider.value = currentHealth;
        fill.color = gradiente.Evaluate(1f);
    }
   //method to set health and slider when taken damage
   //use gradient to change the color of the health bar as it wents down
    public void SetHealth(int health)
   {
       slider.value = health;
       fill.color = gradiente.Evaluate(slider.normalizedValue);
   }
}
