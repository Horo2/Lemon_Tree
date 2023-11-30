using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OasisScript : MonoBehaviour
{
    public Transform playerTransform; // Reference to the player's Transform
    public GameObject[] targetObjects; // Array of GameObjects to enable or disable
    public float activationDistance = 10f; // Distance threshold for activation

    private void Update()
    {
        if (playerTransform == null || targetObjects.Length == 0)
        {
            Debug.LogError("Player transform or target GameObject references are not set!");
            return;
        }

        // Calculate the distance between the player and the script's GameObject (you can change this position)
        float distance = Vector3.Distance(playerTransform.position, transform.position);

        // Enable or disable the target GameObjects based on the distance
        if (distance <= activationDistance)
        {
            EnableObjects();
        }
        else
        {
            DisableObjects();
        }
    }

    private void EnableObjects()
    {
        foreach (GameObject obj in targetObjects)
        {
            obj.SetActive(true); // Enable GameObjects
        }
    }

    private void DisableObjects()
    {
        foreach (GameObject obj in targetObjects)
        {
            obj.SetActive(false); // Disable GameObjects
        }
    }
}
