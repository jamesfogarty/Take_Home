using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public Transform target;
    public float lookSmooth = 0.09f;
    public Vector3 offSet = new Vector3(0, 6, -8);
    public float xTilt = 10;

    Vector3 destination = Vector3.zero;
    PlayerController charController;
    float rotateVel = 0;

    private void Start()
    {
        setCameraTarget(target);
    }

    public void setCameraTarget(Transform t)
    {
        target = t;

        if(target != null)
        {
            if (target.GetComponent<PlayerController>())
            {
                charController = target.GetComponent<PlayerController>();
            }
            else
            {
                Debug.LogError("Camera's target needs a Character controller");
            }
        }
        else
        {
            Debug.LogError("Camera needs a target");
        }
    }

    private void LateUpdate()
    {
        //Moving & rotating
        moveTotarget();
        lookAtTarget();
    }

    void moveTotarget()
    {
        destination = charController.TargetRotation * offSet;
        destination += target.position;
        transform.position = destination;
    }

    void lookAtTarget()
    {
        float eulerYAngle = Mathf.SmoothDampAngle(transform.eulerAngles.y, target.eulerAngles.y, ref rotateVel, lookSmooth);
        transform.rotation = Quaternion.Euler(transform.eulerAngles.x,eulerYAngle,0);
    }


}
