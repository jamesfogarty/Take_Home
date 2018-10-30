using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scorpion : MonoBehaviour {

    public Transform Player;
    int MoveSpeed = 1;
    int MaxDist = 2;
    int MinDist = 1;
    private Animator anim;

    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        transform.LookAt(Player);
        transform.position += transform.forward * MoveSpeed * Time.deltaTime;
        //anim.SetTrigger("glide");
        //anim.SetBool("isMoving", true);
        
        //anim.Play("Scorpion_walk");

        //if (Vector3.Distance(transform.position, Player.position) >= MinDist)
        //{

        //    transform.position += transform.forward * MoveSpeed * Time.deltaTime;



        //    if (Vector3.Distance(transform.position, Player.position) <= MaxDist)
        //    {
        //        //Here Call any function U want Like Shoot at here or something
        //    }

        //}

    }
}
