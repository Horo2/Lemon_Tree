using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class PlantTree : MonoBehaviour
{
    public GameObject smallObject; // Small object when seed is placed
    public GameObject mediumObject; // Medium object when water collides
    public GameObject finalObject; // Final object when light collides
    public GameObject socket;
    public GameObject seed;
    public GameObject water;
    public GameObject light;


    private bool hasSeed = false;
    private bool hasWater = false;
    private bool hasLight = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("water") && hasSeed && !hasWater)
        {
            ChangeToMedium();
            hasWater = true;
            Destroy(water);
        }
        else if (other.CompareTag("light") && hasSeed && hasWater && !hasLight)
        {
            ChangeToFinal();
            hasLight = true;
            Destroy(light);
        }
    }


    private void Update()
    {
        if (!hasSeed)
        {
            XRSocketInteractor s = socket.GetComponent<XRSocketInteractor>();
            if (s.hasSelection && s.selectTarget.gameObject.tag == "seed")
            {
                hasSeed = true;
                EnableSmallObject();
                Destroy(socket);
                Destroy(seed);
            }
        }
       
    }
    private void EnableSmallObject()
    {
        if (smallObject != null)
        {
            smallObject.SetActive(true);
        }
    }

    private void ChangeToMedium()
    {
        if (mediumObject != null)
        {
            mediumObject.SetActive(true);
            if (smallObject != null)
            {
                smallObject.SetActive(false);
            }
        }
    }

    private void ChangeToFinal()
    {
        if (finalObject != null)
        {
            finalObject.SetActive(true);
            if (mediumObject != null)
            {
                mediumObject.SetActive(false);
            }
        }
    }
}