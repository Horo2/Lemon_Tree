using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PrefabSpawn : MonoBehaviour
{
    public GameObject prefabToSpawn;// Generate prefab
    public Transform spawnPoint; // Generation location
    public float floatSpeed = 0.5f; // Speed at which the prefab floats
    public float duration = 10.0f; // Duration for which the prefab floats

    private float elapsedTime = 0.0f;
    private GameObject instantiatedPrefab;
    public void PrefabSpawnCode() //Generation code
    {
        if (prefabToSpawn != null && spawnPoint != null)
        {
            instantiatedPrefab = Instantiate(prefabToSpawn, spawnPoint.position, spawnPoint.rotation);
        }

    }
    void Update()
    {
        // Check if the duration of floating has not exceeded
        if (elapsedTime < duration)
        {
            if (instantiatedPrefab != null)
            {
                // Move the prefab upward
                instantiatedPrefab.transform.Translate(Vector3.up * floatSpeed * Time.deltaTime);

                // Increment the elapsed time
                elapsedTime += Time.deltaTime;
            }
           
        }
        else
        {
            // Destroy the prefab after the specified duration
            SceneManager.LoadSceneAsync("JZ");
        }
    }
}

