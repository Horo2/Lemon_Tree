using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coughing : MonoBehaviour
{
    public static Coughing Instance { get; private set; }

    public AudioClip coughSound; // Assign the coughing sound effect in the inspector
    public AudioSource audioSource;
    private void Awake()
    {
        // Singleton pattern
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("PlayCoughSound", 0, 10);
    }

    // Update is called once per frame
    void PlayCoughSound()
    {
        if (coughSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(coughSound); // Play the coughing sound effect
        }
    }
}
