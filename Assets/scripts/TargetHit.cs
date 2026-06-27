using UnityEngine;

public class TargetHit : MonoBehaviour
{
    public TargetSpawner spawner;

    void OnMouseDown()
    {
        if (spawner != null)
        {
            spawner.SpawnTarget();
        }
        Destroy(gameObject);
    }
}