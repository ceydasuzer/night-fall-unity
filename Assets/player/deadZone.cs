using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class deadZone : MonoBehaviour
{
    public gameManager gameManager;


    [SerializeField] public int scoreCount;

    [SerializeField] private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void displayScore(int scoreCount)
    {
        string newScore = scoreCount.ToString();
        gameManager.scoreText.text = newScore;
    }

    private void OnCollisionEnter(Collision collision)
    {
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
