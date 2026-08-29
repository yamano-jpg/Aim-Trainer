using UnityEngine;

public class TargetMove : MonoBehaviour
{
    public float baseSpeed = 2f;        // 最初の速度
    public float speedPerScore = 0.1f;  // スコア1点ごとの加算量
    public float maxSpeed = 8f;         // 速度の上限
    public float moveRange = 3f;

    private Vector3 startPos;
    private int direction = 1;
    private float moveSpeed;

    void Start()
    {
        startPos = transform.position;
        if (Random.value < 0.5f) direction = -1;

        // 現在のスコアに応じて速度を決める
        GameManager gm = FindAnyObjectByType<GameManager>();
        int score = (gm != null) ? gm.GetScore() : 0;

        moveSpeed = baseSpeed + score * speedPerScore;
        moveSpeed = Mathf.Min(moveSpeed, maxSpeed);
    }

    void Update()
    {
        transform.Translate(Vector3.right * direction * moveSpeed * Time.deltaTime);

        if (Mathf.Abs(transform.position.x - startPos.x) >= moveRange)
        {
            direction *= -1;
        }
    }
}