using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TrackTime : MonoBehaviour
{
    // Set this to the name or tag of the object you want to reference
    public string objectToReference;
    [SerializeField] Timer trackObject;

    void Start()
    {
        // Load the scene where the object is located
        SceneManager.LoadScene("GameScene", LoadSceneMode.Additive);

        // Find the object by name or tag
        GameObject obj = GameObject.Find(objectToReference);

        if (obj != null)
        {
            // Do something with the object, such as access its components
            obj.GetComponent<Renderer>().material.color = Color.red;
            Debug.Log("Object Found");
        }
        else
        {
            Debug.LogWarning("Object not found: " + objectToReference);
        }
    }
}
