using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransToOasis : MonoBehaviour
{

    public Transform teleportTarget; // ָ����λ�õ�Transform���
    private bool playerInTrigger = false; // ���ڼ������Ƿ��ڴ���������

    void Update()
    {
        // �������ڴ����������Ұ�����F��
        if (playerInTrigger && Input.GetKeyDown(KeyCode.Alpha1))
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (player != null)
            {
                // ����Ҵ��͵�ָ��λ��
                player.transform.position = teleportTarget.position;
            }
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // ��ҽ��봥������
            playerInTrigger = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // ����뿪��������
            playerInTrigger = false;
        }
    }
}
