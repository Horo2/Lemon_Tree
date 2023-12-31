using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class Menu : MonoBehaviour
{
    public GameObject m_Menu;
    public Transform playerHead; // Reference to the player's head or main camera.
    public float spawnDistance = 1f; // Distance in front of the player where the menu should appear.
    public InputActionProperty showButton;

    void Start()
    {
        
    }

    void Update()
    {
        if(showButton.action.WasPerformedThisFrame())
        {
            m_Menu.SetActive(!m_Menu.activeSelf);
            m_Menu.transform.position = playerHead.position + new Vector3(playerHead.forward.x, 0 , playerHead.forward.z);
        }

  
            m_Menu.transform.LookAt(new Vector3(playerHead.position.x, m_Menu.transform.position.y, playerHead.position.z));
            
            m_Menu.transform.forward*=-1;
    }

    public void Resume()
    {
        m_Menu.SetActive(false);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
