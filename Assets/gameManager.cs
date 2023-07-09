using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gameManager : MonoBehaviour
{

    public GameObject gameOverMenu;
    public GameObject joystick;
    public GameObject timer;
    public GameObject pausePanel;

    public Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        gameOverMenu.SetActive(false);
    }

    public void pauseGame()
    {
        pausePanel.SetActive(true);
        joystick.SetActive(false);
        timer.SetActive(false);
    }

    public void resumeGame()
    {
        pausePanel.SetActive(false);
        joystick.SetActive(true);
        timer.SetActive(true);
    }

    public void returnMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void gameOver()
    {
        gameOverMenu.SetActive(true);
        joystick.SetActive(false);
        timer.SetActive(false);
    }
}
