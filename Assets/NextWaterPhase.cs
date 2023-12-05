using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextWaterPhase : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // 玩家进入触发区域
            GameObject gameObject = GameObject.Find("GameStateManager");
            gameObject.GetComponent<GameStateManager>().nextPhase();
        }
    }

}
