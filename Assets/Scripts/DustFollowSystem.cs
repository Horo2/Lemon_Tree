using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DustFollowSystem : MonoBehaviour
{
    public Transform objectToFollow; // Reference to the object you want to follow

    void Update()
    {
        if (objectToFollow != null)
        {
            // Update the position of this object to match the position of the object to follow
            transform.position = objectToFollow.position;
        }
        else
        {
            Debug.LogWarning("Object to follow is not assigned. Please assign a valid object.");
        }
    }
}
