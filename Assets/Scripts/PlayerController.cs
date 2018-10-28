using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    [SerializeField] private Transform player;
    [SerializeField] private Transform spawnPos;

    public Animation anim;

    [System.Serializable]
    public class moveSettings
    {
        public float forwardVel = 12;
        public float rotateVel = 100;
        public float jumpVelocity = 25;
        public float distToGrounded = 0.5f;
        public LayerMask ground;
        private int jumpCount = 0;
        

    }

    [System.Serializable]
    public class physSettings
    {
        public float downAccel = 0.75f;
    }

    [System.Serializable]
    public class inputSettings
    {
        public float inputDelay = 0.1f;
        public string FORWARD_AXIS = "Vertical";
        public string TURN_AXIS = "Horizontal";
        public string JUMP_AXIS = "Jump";
    }

    public moveSettings moveSetting = new moveSettings();
    public physSettings phsSetting = new physSettings();
    public inputSettings inputSetting = new inputSettings();

    Vector3 velocity = Vector3.zero;
    Quaternion targetRotation;
    Rigidbody rBody;
    float forwardInput = 0;
    float turnInput = 0;
    float jumpInput = 0;


    public Quaternion TargetRotation
    {
        get { return targetRotation; }
    }

    bool grounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, moveSetting.distToGrounded, moveSetting.ground);
    }

    void Start()
    {
        anim = GetComponent<Animation>();
        targetRotation = transform.rotation;
        if (GetComponent<Rigidbody>())
        {
            rBody = GetComponent<Rigidbody>();
        }
        else
        {
            Debug.LogError("Character needs a rigid body");
        }

        forwardInput = turnInput = 0;
        
    }

    void GetInput()
    {
        forwardInput = Input.GetAxis(inputSetting.FORWARD_AXIS);
        turnInput = Input.GetAxis(inputSetting.TURN_AXIS);
        jumpInput = Input.GetAxisRaw(inputSetting.JUMP_AXIS);
    }

    void Update()
    {
        GetInput();
        turn();
    }

    void FixedUpdate()
    {
        run();
        jump();

        rBody.velocity = transform.TransformDirection(velocity);
        if(rBody.position.y < -5)
        {
            resetPos();
        }
    }

    private void resetPos()
    {
        player.transform.position = spawnPos.transform.position;
    }

    void run()
    {
        if (Mathf.Abs(forwardInput) > inputSetting.inputDelay)
        {
            anim.Play("Run");
            velocity.z = moveSetting.forwardVel * forwardInput;
        }
        else
        {
            if (grounded())
            {
                anim.Play("Idle");
            }
            velocity.z = 0;
        }
    }

    void turn()
    {
        if(Mathf.Abs(turnInput) > inputSetting.inputDelay)
        {
            targetRotation *= Quaternion.AngleAxis(moveSetting.rotateVel * turnInput * Time.deltaTime, Vector3.up);
        }      
        transform.rotation = targetRotation;
    }

    void jump()
    {
        if(jumpInput > 0 && grounded())
        {
            //Jump
            anim.Play("Jump01");
            velocity.y = moveSetting.jumpVelocity;
        }
        else if(jumpInput == 0 && grounded())
        {
            //Zero out velocity
            velocity.y = 0;
        }
        else
        {
            //No grounded, decrease Y velocity
            velocity.y -= phsSetting.downAccel;
        }
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if(other.tag == "platform")
    //    {
    //        Debug.Log("Platform Hit");
    //        player.transform.parent = transform;
    //    }
    //}
}
