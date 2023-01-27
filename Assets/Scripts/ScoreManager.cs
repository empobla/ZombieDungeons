/*
    Global counter of points

    Author: Isaac Garza 
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ScoreManager : MonoBehaviour
{
   public int totalPoints = 0;
   public Text levelText;

   void Start()
   {
      //Recover the saved value
      totalPoints = PlayerPrefs.GetInt("Health", 0);
      levelText.text = totalPoints.ToString();        
   }

   void Update()
   {  //points depend on the health of the player 
      totalPoints = PlayerPrefs.GetInt("Health", 0);
      levelText.text = totalPoints.ToString();
      if (totalPoints == 0)
      {
         PlayerPrefs.SetInt("Health", 0);
         totalPoints = PlayerPrefs.GetInt("Health", 0);
         levelText.text = totalPoints.ToString();
      }   
   }
   public int getHighscore()
   {
      return PlayerPrefs.GetInt("Health");
   }

}
