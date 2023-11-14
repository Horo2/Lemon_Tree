using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyOnLoadXROrig : MonoBehaviour
{
    private static DontDestroyOnLoadXROrig instance;

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
