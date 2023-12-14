using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckGameState : MonoBehaviour
{
    [SerializeField]
    public GameObject gameObject1;
    public GameObject gameObject2;
    public GameObject gameObject3;
    private PlantTree dirtPile;

    void Awake()
    {
        GameObject gameObject = GameObject.Find("GameStateManager");
        dirtPile = GameObject.Find("Dirt_Pile").GetComponent<PlantTree>();
        
        int i = gameObject.GetComponent<GameStateManager>().phase();
        SetKeyActive(i);
        dirtPile.seed = GameObject.Find("seed");
        dirtPile.water = GameObject.Find("Water");
        dirtPile.light = GameObject.Find("Light");
    }
    public void SetKeyActive(int i)
    {
        if (i == 1)
        {
            gameObject1.SetActive(true);
        }
        if(i == 2)
        {
            if (!dirtPile.hasSeed)
            {
                gameObject1.SetActive(true);
            }
            gameObject2.SetActive(true);
        }
        if(i ==3)
        {
            if (!dirtPile.hasSeed)
            {
                gameObject1.SetActive(true);
            }

            if (!dirtPile.hasWater)
            {
                gameObject2.SetActive(true);
            }
            gameObject3.SetActive(true);
        }
    }
    
}
