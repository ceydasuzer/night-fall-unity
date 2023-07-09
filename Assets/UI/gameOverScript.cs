using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gameOverScript : MonoBehaviour
{
    //public Text pointsText;

    //function for manipulating high score element on game over screen
    public void SetUp(int score)
    {
        gameObject.SetActive(true);
        //pointsText.text = score.ToString() + " POINTS";
    }

    //function for restarting the game using scene manager
    //calling this function on unity via the play again button on game over screen
    public void RestartButton()
    {
        SceneManager.LoadScene("Game");
    }

    //function for returning to the main menu using scene manager 
    //calling this function on unity via main menu button on game over screen
    public void ExitButton()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
