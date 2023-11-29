using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportToLevel1 : MonoBehaviour
{

    public GameStateManager State;



    private bool playerInTrigger = false; // 用于检查玩家是否在触发区域内

    private void Awake()
    {

    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // 玩家进入触发区域
            Debug.Log("玩家进入触发区域");
            playerInTrigger = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // 玩家离开触发区域
            Debug.Log("玩家离开触发区域");
            playerInTrigger = false;
        }
    }
}
