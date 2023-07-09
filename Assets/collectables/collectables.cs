using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collectables : MonoBehaviour
{
    float speed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //collectable player'ýn push gücünü arttýracak
    }

    private void FixedUpdate()
    {
        transform.Rotate(Vector3.up * speed * Time.deltaTime);
    }
}
