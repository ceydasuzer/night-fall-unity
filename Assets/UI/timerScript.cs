using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timerScript : MonoBehaviour
{
    //defining timeValue variable and setting it to 60
    public float timeValue = 60;
    public Text timerText;


    //calling game manager game object to use the game over method inside
    public gameManager gameManager;


    // Update is called once per frame
    void Update()
    {
        
        if(timeValue > 0)
        {
            timeValue -= Time.deltaTime; //to stabilize the time for every device
        }
        else
        {
            timeValue = 0;

            gameManager.gameOver(); // game over when time hits 0
        }


        DisplayTime(timeValue);
    }

    void DisplayTime(float timeToDisplay)
    {
        if(timeToDisplay < 0)
        {
            timeToDisplay = 0;
        }

        //using math to calculate minutes and seconds
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        //formatting the text string for displaying time
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
