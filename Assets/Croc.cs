using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Croc : MonoBehaviour {
    public GameObject player;
    public Transform Player;
    private PlayerController c;
    int MoveSpeed = 1;
    int MaxDist = 2;
    int MinDist = 1;
    float distance;
    private Animation anim;

    // Use this for initialization
    void Start()
    {
        c = player.GetComponent<PlayerController>();
        anim = GetComponent<Animation>();
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(Player.position, transform.position);
        Debug.Log(distance);
        
        
        if(distance < 30 && c.grounded())
        {
            anim.Play("Crocodile_walk");
            //anim.Play("Crocodile_run");
            
            transform.LookAt(Player);
            transform.position += transform.forward * MoveSpeed * Time.deltaTime;
        }
        
    }
}
