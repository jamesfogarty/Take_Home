using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

    public Text counter;
    public float mins, secs;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        mins = (int)(Time.timeSinceLevelLoad / 60f);
        secs = (int)(Time.timeSinceLevelLoad % 60f);
        counter.text = mins.ToString("00") + ":" + secs.ToString("00");
	}
}
