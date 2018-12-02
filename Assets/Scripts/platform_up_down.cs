using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platform_up_down : MonoBehaviour {

    // declare this and initialize outside your function
    Vector3 moveDirection = Vector3.up; // *assuming your platform starts at the bottom
    public GameObject player;
    public float speed;
    public float max, min;
    void move()
    {
        if (transform.position.y >= max)
        {
            moveDirection = Vector3.down;
        }
        else if(transform.position.y <= min)
        {
            moveDirection = Vector3.up;
        }
        // implicit else... if it's in between, it should keep moving in the same direction it last was...

        transform.Translate(moveDirection * Time.deltaTime * speed);
    }

    private void Update()
    {
        move();
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.tag);
        if (other.tag == "Player")
        {
            player.transform.parent = transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Left Platform");
        if (other.tag == "Player")
        {
            player.transform.parent = null;
        
        }
    }
}
