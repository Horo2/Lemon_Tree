using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckGameState : MonoBehaviour
{
    [SerializeField]
    public GameObject gameObject1;
    public GameObject gameObject2;
    public GameObject gameObject3;

    
    void Awake()
    {
        GameObject gameObject = GameObject.Find("GameStateManager");
        int i = gameObject.GetComponent<GameStateManager>().phase();
        SetKeyActive(i);
    }
    public void SetKeyActive(int i)
    {
        if (i == 1)
        {
            gameObject1.SetActive(true);
        }
        if(i == 2)
        {
            gameObject2.SetActive(true);
        }
        if(i ==3)
        {
            gameObject3.SetActive(true);
        }
    }
    
}
