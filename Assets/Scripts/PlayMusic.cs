using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class PlayMusic : MonoBehaviour
{
    public List<GameObject> socketContainers; // List of the socket containers (each child object)
    private List<bool> socketFilledStates; // List to keep track of whether sockets are filled
    public List<AudioClip> musicTracks; // List of music tracks to play based on the state

    private AudioManager audioManager;
    public PrefabSpawn prefabSpawn;
    private AudioClip currentClip;

    private void Start()
    {
        GameObject audioManagerObject = GameObject.FindWithTag("AudioManager");

        if (audioManagerObject != null)
        {
            audioManager = audioManagerObject.GetComponent<AudioManager>();
        }
        // Initialize the socketFilledStates list with all sockets initially unfilled
        socketFilledStates = new List<bool>(new bool[socketContainers.Count]);
    }

    private void Update()
    {
        // Check for changes in socket states and update the audio track accordingly
        for (int i = 0; i < socketContainers.Count; i++)
        {
            XRSocketInteractor socketInteractable = socketContainers[i].GetComponentInChildren<XRSocketInteractor>();

            if (socketInteractable != null)
            {
                bool socketFilled = socketInteractable.hasSelection; // Check if the socket is filled

                if (socketFilled != socketFilledStates[i])
                {
                    socketFilledStates[i] = socketFilled;
                    PlayMusicBasedOnState();
                }
            }
        }
    }

    private void PlayMusicBasedOnState()
    {
        Debug.Log("Switching Music");
        // Generate a key based on the socketFilledStates list
        string stateKey = string.Join("-", socketFilledStates.ConvertAll(x => x ? "1" : "0").ToArray());
        Debug.Log("statekey: " + stateKey);
        // Search for a matching state in the musicTracks list
        int index = musicTracks.FindIndex(track => track.name == stateKey);
        Debug.Log("index: " + index);
        // If a matching state is found, play the corresponding music
        if (index >= 0)
        {
            currentClip = musicTracks[index];
            audioManager.PlayMusicEffect(currentClip);
        }
        
        if(stateKey == "1-0-1-1-1")
        {
             if(prefabSpawn != null)
            {
                GameObject gameObject = GameObject.Find("GameStateManager");
                gameObject.GetComponent<GameStateManager>().nextPhase();
                prefabSpawn.PrefabSpawnCode();
            }
        }
    }
}