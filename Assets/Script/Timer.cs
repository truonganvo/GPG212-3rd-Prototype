using System;
using System.Collections;
using System.Collections.Generic;
using System.Timers;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI secondsS;

    [SerializeField] float seconds = 0;
    private bool reachDestination;

    private void Start()
    {
        reachDestination = false;
    }
    private void Update()
    {
        secondsS.text = seconds.ToString("0.00");

        if (reachDestination != true)
        {
            seconds += Time.deltaTime;
        }
    }



    public void FinishLine()
    {
        reachDestination = true;
    }
}
