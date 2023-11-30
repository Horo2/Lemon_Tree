using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnScreenText : MonoBehaviour
{
    public DialogSystem dialogSystem;
    // Start is called before the first frame update
    void Start()
    {
        dialogSystem.GetComponent<DialogSystem>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider player)
    {

        if (player.gameObject.tag == "Player")
        {
            dialogSystem.GetComponent<DialogSystem>().enabled = true;
        }
    }
}
