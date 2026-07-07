using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text timerText;

    [SerializeField] private float gameTime = 60f;

    private int score;
    private float currentTime;

    public int Score => score;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        score = 0;
        currentTime = gameTime;

        UpdateScoreUI();
        UpdateTimerUI();
    }

    private void Update()
    {
        currentTime -= Time.deltaTime;

        if (currentTime <= 0f)
        {
            currentTime = 0f;
            UpdateTimerUI();

            ScoreData.Score = score;

            SceneManager.LoadScene("ResultScene");
            return;
        }

        UpdateTimerUI();
    }

    public void AddScore(int value)
    {
        score += value;
        UpdateScoreUI();
    }

    private void UpdateScoreUI()
    {
        scoreText.text = $"Score : {score}";
    }

    private void UpdateTimerUI()
    {
        timerText.text = $"Time : {Mathf.CeilToInt(currentTime)}";
    }
}