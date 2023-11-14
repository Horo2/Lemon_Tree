using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR;

public class SceneManagement : MonoBehaviour
{

    public string name;

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
    }
}