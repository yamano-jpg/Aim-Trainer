using UnityEngine;

public class TargetHit : MonoBehaviour
{
    public TargetSpawner spawner;
    public AudioClip hitSound; // 効果音
    private GameManager gameManager;
    private AudioSource audioSource;   


    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        audioSource = FindObjectOfType<AudioSource>();
    }

    void OnMouseDown()
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