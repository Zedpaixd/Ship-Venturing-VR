using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ClockController : MonoBehaviour
{
    public GameObject ClockHour;
    public GameObject ClockMinute;
    public GameObject ClockSeconds;

    private DateTime currentTime;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currentTime = DateTime.Now;
        ClockSeconds.transform.rotation = Quaternion.Euler(new Vector3(90 + Convert.ToInt32(currentTime.Second * 6), 0, -90));
        ClockMinute.transform.rotation = Quaternion.Euler(new Vector3(90 + Convert.ToInt32(currentTime.Minute * 6), 0, -90));
        ClockHour.transform.rotation = Quaternion.Euler(new Vector3(90 + (currentTime.Hour % 12) * 30, 0, -90));
    }
}
