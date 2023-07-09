using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collectables : MonoBehaviour
{
    float speed = 10f;


    // rotating the collectable items by y axis
    private void FixedUpdate()
    {
        transform.Rotate(Vector3.up * speed * Time.deltaTime);
    }
}
