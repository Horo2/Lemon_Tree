using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabSpawn : MonoBehaviour
{
    public GameObject prefabToSpawn;// Generate prefab
    public Transform spawnPoint; // Generation location
    public void PrefabSpawnCode() //Generation code
    {
        if (prefabToSpawn != null && spawnPoint != null)
        {
            Instantiate(prefabToSpawn, spawnPoint.position, spawnPoint.rotation);
        }
    }
}
