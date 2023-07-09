using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class deadZone : MonoBehaviour
{

    public gameManager gameManager;

    //declaring a score variable to hold the count
    [SerializeField] public int scoreCount;

    [SerializeField] private Animator anim;

    //function for displaying the score in UI canvas score object
    public void displayScore(int scoreCount)
    {
        string newScore = scoreCount.ToString();
        gameManager.scoreText.text = newScore;
    }

    //adding collisionEnter function to catch the enemies that wandered outside of the platform
    private void OnCollisionEnter(Collision collision)
    {
        //destroying the enemy that collides 
        //increasing the score and sending the score to displayScore funtion
        if (collision.gameObject.tag == "enemy")
        {
            Destroy(collision.gameObject, 0.5f);
            scoreCount += 1;
            print(scoreCount);
            displayScore(scoreCount);
        }

        if(collision.gameObject.tag == "Player")
        {
            print("player dead zone");

            //activating falling animation on animator 
            anim.SetBool("isFalling", true);

            //using invoke to delay the game over screen
            gameManager.Invoke("gameOver", 2);
        }
    }


}
