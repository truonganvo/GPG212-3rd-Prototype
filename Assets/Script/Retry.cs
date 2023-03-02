using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Retry : MonoBehaviour
{
    [SerializeField] GameObject enableCanvas;
    public void Restart()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void EnableCanvas()
    {
        enableCanvas.SetActive(true);
    }
}
