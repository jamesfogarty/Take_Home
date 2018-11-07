using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Jumper : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            jumpHigher(other);
        }
    }

    private void jumpHigher(Collider player)
    {
        PlayerController p = player.GetComponent<PlayerController>();
        p.moveSetting.jumpVelocity = 35;
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Left " + other.tag.ToString());
    }
}
