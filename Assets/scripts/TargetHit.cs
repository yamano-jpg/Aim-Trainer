using UnityEngine;

public class TargetHit : MonoBehaviour
{
    public TargetSpawner spawner;
    private GameManager gameManager;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    void OnMouseDown()
    {
        if (spawner != null)
            spawner.SpawnTarget();

        if (gameManager != null)
            gameManager.AddScore();

        Destroy(gameObject);
    }
}