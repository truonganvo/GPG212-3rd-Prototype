using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CountDown : MonoBehaviour
{
    [SerializeField] float countDown = 25f;
    [SerializeField] TextMeshProUGUI textMeshProUGUI;
    [SerializeField] GameObject enableTimer;
    [SerializeField] GameObject player;

    [SerializeField] AudioSource raceStarting;
    [SerializeField] AudioClip raceStartingNow;



    private void Update()
    {
        textMeshProUGUI.text = countDown.ToString("00");
        countDown -= Time.deltaTime;

        if (countDown <= 5)
        {
            player.SetActive(true);
        }

        if (countDown <= 3)
        {
            raceStarting.PlayOneShot(raceStartingNow);
        }

        if (countDown <= 0)
        {
            countDown = 0;
            enableTimer.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
