using UnityEngine;

public class TargetSpawner : MonoBehaviour
{
    public GameObject targetPrefab;
    public float spawnRangeX = 4f;
    public float spawnRangeY = 2f;
    public float spawnZ = 8f;
    public float minHeight = 1f;

    public void SpawnTarget()
    {
        float randomX = Random.Range(-spawnRangeX, spawnRangeX);
        float randomY = Random.Range(minHeight, minHeight + spawnRangeY);

        Vector3 spawnPos = new Vector3(randomX, randomY, spawnZ);
        GameObject newTarget = Instantiate(targetPrefab, spawnPos, Quaternion.identity);

        TargetHit hitScript = newTarget.GetComponent<TargetHit>();
        if (hitScript != null)
        {
            hitScript.spawner = this;
        }
    }
}