using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Win : MonoBehaviour
{
    [SerializeField] Timer stopTime;
    [SerializeField] GameObject timeRecord;
    private void Start()
    {

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("HELL YEAH!!!");
            stopTime.FinishLine();
            timeRecord.SetActive(true);
        }
    }
}
