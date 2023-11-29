using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransToOasis : MonoBehaviour
{

    public Transform teleportTarget; // 指定新位置的Transform组件
    private bool playerInTrigger = false; // 用于检查玩家是否在触发区域内

    void Update()
    {
        // 如果玩家在触发区域内且按下了F键
        if (playerInTrigger && Input.GetKeyDown(KeyCode.Alpha1))
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (player != null)
            {
                // 将玩家传送到指定位置
                player.transform.position = teleportTarget.position;
            }
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // 玩家进入触发区域
            playerInTrigger = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // 玩家离开触发区域
            playerInTrigger = false;
        }
    }
}
