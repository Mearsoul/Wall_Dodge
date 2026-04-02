using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro; 
using System.Collections;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public GameSettings settings;
    
    [Header("UI Elementleri")]
    public GameObject gameOverPanel;
    public TextMeshProUGUI scoreText; 
    public TextMeshProUGUI highScoreText; 

    private int currentScore = 0;
    private int highScore = 0;
    public bool isGameOver = false;

    public float currentSpeed { get; private set; }

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    private void Start()
    {
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        if(gameOverPanel != null) gameOverPanel.SetActive(false); 
        
        StartGame();
    }

    public void StartGame()
    {
        isGameOver = false;
        currentScore = 0;
        
        currentSpeed = settings.gameSpeed; 
        Time.timeScale = 1f;

        UpdateScoreUI(); 
        UpdateHighScoreUI(); 
        
        StartCoroutine(TimeScoreRoutine());
    }

    private IEnumerator TimeScoreRoutine()
    {
        while (!isGameOver)
        {
            yield return new WaitForSeconds(1f); 
            AddScore(1); 
            currentSpeed += settings.speedMultiplier; 
        }
    }

    public void AddScore(int amount)
    {
        if (isGameOver) return;
        
        currentScore += amount;

        if (currentScore > highScore)
        {
            highScore = currentScore;
            PlayerPrefs.SetInt("HighScore", highScore); 
            UpdateHighScoreUI(); 
        }

        UpdateScoreUI(); 
    }

    private void UpdateScoreUI()
    {
        if (scoreText != null)
        {
            scoreText.text = "Skor: " + currentScore;
        }
    }

    private void UpdateHighScoreUI()
    {
        if (highScoreText != null)
        {
            highScoreText.text = "En Yüksek: " + highScore;
        }
    }

    public void GameOver()
    {
        isGameOver = true;
        Time.timeScale = 0f; 
        
        if(gameOverPanel != null) gameOverPanel.SetActive(true); 
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); 
    }

   
    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenuScene"); 
    }
}