using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Jumper : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        PlayerController player = other.
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Left");
    }
}
