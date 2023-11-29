using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportToLevel1 : MonoBehaviour
{

    public GameStateManager State;



    private bool playerInTrigger = false; // ���ڼ������Ƿ��ڴ���������

    private void Awake()
    {

    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // ��ҽ��봥������
            Debug.Log("��ҽ��봥������");
            playerInTrigger = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // ����뿪��������
            Debug.Log("����뿪��������");
            playerInTrigger = false;
        }
    }
}
