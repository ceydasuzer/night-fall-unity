using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenu : MonoBehaviour
{

    // method for exiting the game
    //calling this method on unity via exit button's onclick event
    public void ExitButton()
    {
        Application.Quit();
    }

    //method for start button on main menu
    //using scene manager to load the scene I called "game" 
    //calling this method on unity via start button's onclick event
    public void StartGame()
    {
        SceneManager.LoadScene("Game");
    }
}
