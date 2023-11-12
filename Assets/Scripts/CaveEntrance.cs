using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaveEntrance : MonoBehaviour
{
    // Start is called before the first frame update
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            DestroyObjectsInCave();
        }
    }

    void DestroyObjectsInCave()
    {
        // Add your logic to destroy objects here.
        // For example, finding objects by tag or name and destroying them.

        // Example: Destroying objects with a specific tag
        GameObject[] objectsToDestroy = GameObject.FindGameObjectsWithTag("Particle");

        foreach (GameObject obj in objectsToDestroy)
        {
            Destroy(obj);
        }
    }
}
