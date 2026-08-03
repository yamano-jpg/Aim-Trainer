using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI timerText;
    public GameObject resultPanel;
    public TextMeshProUGUI resultScoreText;
    public GameObject crosshair;

    public float timeLimit = 60f;

    int score = 0;
    float timeLeft;
    public bool isGameOver = false;
    public bool isPaused = false;

    void Start()
    {
        AudioSource bgm = FindObjectOfType<AudioSource>();
    if (bgm != null) bgm.volume = MenuSettings.bgmVolume;
    
        timeLeft = timeLimit;
        UpdateScoreText();
        UpdateTimerText();

        if (resultPanel != null)
            resultPanel.SetActive(false);
    }

    void Update()
    {
        if (isGameOver) return;
        if (isPaused) return;

        timeLeft -= Time.deltaTime;

        if (timeLeft <= 0)
        {
            timeLeft = 0;
            isGameOver = true;
            ShowResult();
        }

        UpdateTimerText();
    }

    public void AddScore()
    {
        if (isGameOver) return;
        score++;
        UpdateScoreText();
    }

    void UpdateScoreText()
    {
        if (scoreText != null)
            scoreText.text = "Score: " + score;
    }

    void UpdateTimerText()
    {
        if (timerText != null)
            timerText.text = "Time: " + Mathf.CeilToInt(timeLeft);
    }

    void ShowResult()
{
    if (resultPanel != null)
    {
        resultPanel.SetActive(true);
        if (resultScoreText != null)
            resultScoreText.text = "Score: " + score;
    }

    if (crosshair != null)
        crosshair.SetActive(false);

        Time.timeScale = 0f;

    Cursor.lockState = CursorLockMode.None;
    Cursor.visible = true;
}
public void BackToMenu()
{
    Time.timeScale = 1f;
    SceneManager.LoadScene("MainMenu");
}
}
