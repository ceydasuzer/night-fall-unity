using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemyScript : MonoBehaviour
{

    //getting ground check game object i will need to check if the player is on the platform
    public Transform GroundCheck;

    //declaring a layer mask that will be set on unity as ground
    public LayerMask ground;

    [SerializeField] private float pushAway;

    public GameObject player;

    //declaring anemies array
    public GameObject[] otherEnemies;
    public GameObject nearestObject;
    float distance;
    float nearestDistance= 10000;


    public NavMeshAgent navigation;

    // Start is called before the first frame update
    void Start()
    {
        otherEnemies = GameObject.FindGameObjectsWithTag("enemy");
        navigation = GetComponent<NavMeshAgent>();   
    }


    private void Update()
    { 
        //for loop to find the nearest object in the enemies array
            for (int i = 0; i < 7; i++)
            {

                if (nearestObject != null)
                {

                    distance = Vector3.Distance(this.transform.position, otherEnemies[i].transform.position);


                    if (distance < nearestDistance)
                    {
                        nearestObject = otherEnemies[i + 1];
                        nearestDistance = distance;
                    }

                //getting navmesh agent go to the nearest object

                navigation.SetDestination(nearestObject.transform.position);
                }
                else //if nearest object is null navmesh agent goes after the player
                {
                    navigation.SetDestination(player.transform.position);
                }

            }
        }




    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "enemy" || collision.gameObject.tag == "Player")
        {
            // getting the rigidbody of the collided object
            Rigidbody rigid = collision.gameObject.GetComponent<Rigidbody>();

            //normalizing the vector3 parameters  
            Vector3 direction = (collision.transform.position - gameObject.transform.position).normalized;

            // adding force to rigid variable to push the other object
            rigid.AddForce(new Vector3(direction.x, 0, direction.z) * pushAway, ForceMode.Impulse);
        }
    }

}
