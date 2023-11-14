using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestryOnLoadXRDeviceSimulator : MonoBehaviour
{
    private static DontDestryOnLoadXRDeviceSimulator instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            // If an instance already exists, destroy this new instance
            Destroy(gameObject);
        }
    }
}
