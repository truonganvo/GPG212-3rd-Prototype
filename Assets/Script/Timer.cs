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
    [SerializeField] TextMeshProUGUI trackTheScore;

    private float trackScore;
    [SerializeField] float seconds = 0;
    private bool reachDestination;

    private void Start()
    {
        reachDestination = false;
    }
    private void Update()
    {
        trackTheScore.text = PlayerPrefs.GetFloat("HighScore", 0f).ToString();
        secondsS.text = seconds.ToString("0.00");
        trackTheScore.text = trackScore.ToString();

        if (reachDestination != true)
        {
            seconds += Time.deltaTime;
            trackScore = seconds;
        }
    }



    public void FinishLine()
    {
        reachDestination = true;
        if (seconds < PlayerPrefs.GetFloat("HighScore", 0f))
        {
            PlayerPrefs.SetFloat("HighScore", seconds);
            trackTheScore.text = seconds.ToString();
        }
        else
        {
            trackTheScore.text = trackScore.ToString();
            PlayerPrefs.SetFloat("HighScore", trackScore);
        }
    }
}
