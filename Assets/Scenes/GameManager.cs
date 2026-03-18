using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int score = 0;
    public float time = 0f;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI timeText;

    public GameObject gameOverPanel;
    public TextMeshProUGUI finalScoreText;
    public TextMeshProUGUI finalTimeText;

    private bool isGameOver = false;

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        if (!isGameOver)
        {
            time += Time.deltaTime;

            timeText.text = "Time: " + Mathf.FloorToInt(time);
        }
    }

    public void AddScore(int points)
    {
        score += points;
        scoreText.text = "Score: " + score;
    }

    public void GameOver()
    {
        isGameOver = true;
        Time.timeScale = 0f;

        scoreText.gameObject.SetActive(false);
        timeText.gameObject.SetActive(false);

        gameOverPanel.SetActive(true);

        finalScoreText.text = "Score: " + score;
        finalTimeText.text = "Time: " + Mathf.FloorToInt(time);
    }
    private void Start()
    {
        gameOverPanel.SetActive(false);
    }
    public void RestartGame()
    {
        Time.timeScale = 1f; // resume time
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}