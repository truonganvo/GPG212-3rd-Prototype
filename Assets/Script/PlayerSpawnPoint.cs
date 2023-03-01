using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawnPoint : MonoBehaviour
{
    public Transform spawnPoint1;
    public Transform spawnPoint2;

    [SerializeField] GameObject playerPrefab;

    // Start is called before the first frame update
    void Start()
    {
        // Randomly select one of the two spawn points
        if (Random.Range(0, 2) == 0)
        {
            Instantiate(playerPrefab, spawnPoint1.position, spawnPoint1.rotation);
            // Spawn at the first spawn point
            transform.position = spawnPoint1.position;
        }
        else
        {
            Instantiate(playerPrefab, spawnPoint2.position, spawnPoint1.rotation);
            // Spawn at the second spawn point
            transform.position = spawnPoint2.position;
        }
    }
}
