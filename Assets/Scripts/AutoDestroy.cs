using UnityEngine;

public class AutoDestroy : MonoBehaviour
{
    public float destroyTime = 10f; // Time in seconds before destroying the object

    private void Start()
    {
        Invoke("DestroyObject", destroyTime);
    }

    private void DestroyObject()
    {
        Destroy(gameObject);
    }
}