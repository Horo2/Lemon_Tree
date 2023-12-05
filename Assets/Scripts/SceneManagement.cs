using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR;

public class SceneManagement : MonoBehaviour
{

    public string name;
    public AudioClip level1Solution;
    private bool playerInTrigger = false; // 用于检查玩家是否在触发区域内

    public GameStateManager State;

    void Update()
    {
        // 如果玩家在触发区域内且按下了F键
        if (playerInTrigger&&Input.anyKey)
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (player != null)
            {
                // 将玩家传送到指定位置
                SwitchScene();
            }
        }
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

    void SwitchScene()
    {
        //家人们，准备传送咯
        GameObject gameObject = GameObject.Find("GameStateManager");
        gameObject.GetComponent<GameStateManager>().nextPhase();
        SceneManager.LoadSceneAsync(name);
        if (name == "Level 1_Cave-1")
        {
            if(level1Solution != null)
            {
                FindAnyObjectByType<AudioManager>().PlayMusicEffect(level1Solution);
            }           
        }
    }
}