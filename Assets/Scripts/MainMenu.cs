/*
Script to change scene depending where you are 		
Alejandra Nissan Leizorek		
*/

using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public void GotoScene() 
    {
    SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex + 1); 
    }

    //quit game 
    public void QuitGame ()
    {
        //Debug.Log ("QUIT!");
        Application.Quit();
    }

    public void GotoScene(string scene)
    {   
        if (scene == "Level1")
        {
            PlayerPrefs.SetInt("KeyPicked",0);
            PlayerPrefs.SetInt("Health",100);
        }

    // Change to the scene sent as a parameter        
        SceneManager.LoadScene(scene);   
    }
 
}
