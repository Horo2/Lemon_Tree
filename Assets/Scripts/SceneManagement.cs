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

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SwitchScene();
        }
    }

    void SwitchScene()
    {
        //家人们，准备传送咯
        
        SceneManager.LoadSceneAsync(name);
        if (name == "Level 1_Cave-1")
        {
            FindAnyObjectByType<AudioManager>().PlayMusicEffect(level1Solution);
        }
    }
}