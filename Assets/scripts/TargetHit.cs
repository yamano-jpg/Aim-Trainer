using UnityEngine;

public class TargetHit : MonoBehaviour
{
    public TargetSpawner spawner;
    public AudioClip hitSound;
    private GameManager gameManager;

    void Start()
    {
        gameManager = FindAnyObjectByType<GameManager>();
    }

    public void Hit()
    {
        if (spawner != null)
            spawner.SpawnTarget();

        if (gameManager != null)
            gameManager.AddScore();

        if (hitSound != null)
            AudioSource.PlayClipAtPoint(hitSound, transform.position, MenuSettings.seVolume);

        Destroy(gameObject);
    }
}