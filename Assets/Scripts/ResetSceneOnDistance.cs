using UnityEngine;

public class ResetSceneOnDistance : MonoBehaviour
{
    public Transform player;//玩家位置
    public Transform targetObject; //初始点
    public float resetDistance = 40f;//检测距离

    public Vector3 initialPlayerPosition;//玩家初始位置
    public Collider noResetZone; //停止重置

    private bool isPlayerInNoResetZone = false;

    void Update()
    {
       
       float distance = Vector3.Distance(player.position, targetObject.position);
       //检测玩家是否在正确绿洲里

        if (!isPlayerInNoResetZone && distance >= resetDistance)
        {
            player.position = initialPlayerPosition;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other == noResetZone)
        {
            isPlayerInNoResetZone = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other == noResetZone)
        {
            isPlayerInNoResetZone = false;
        }
    }
}
