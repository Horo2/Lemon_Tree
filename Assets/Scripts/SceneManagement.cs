using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        SceneManager.LoadScene(name);
    }
}