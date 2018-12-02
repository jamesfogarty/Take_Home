using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jumper : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Entered trampoline");
        if(other.tag == "Player")
        {
            launchPlayer(other);
        }
    }

    private void launchPlayer(Collider player)
    {
        PlayerController current = GetComponent<PlayerController>();
        
    }
}
