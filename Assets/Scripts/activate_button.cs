using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activate_button : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("PLAYER IN CONTACT WITH BUTTON");
        if(other.tag == "Player")
        {
            gameObject.GetComponent<Renderer>().material.color = Color.green;
        }
    }
}
