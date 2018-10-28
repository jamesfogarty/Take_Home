using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Entered trigger");
        if (other.CompareTag("Player"))
        {
            jumpHigher(other);
        }
    }

    private void jumpHigher(Collider player)
    {
        Debug.Log("Jump Higher");
        PlayerController current = player.GetComponent<PlayerController>();
        current.moveSetting.jumpVelocity = 40;
    }

}
