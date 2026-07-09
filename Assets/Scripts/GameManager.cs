using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text timerText;

    [SerializeField] private float gameTime = 60f;

    [SerializeField] private AudioSource seSource;
    [SerializeField] private AudioClip countdownSE;

    [SerializeField] private AudioSource bgmSource;

    private int lastSecond;
    private bool speedUpBGM;

    private int score;
    private float currentTime;

    public bool HitThisFrame { get; set; }

    public int Score => score;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        score = 0;
        currentTime = gameTime;

        lastSecond = Mathf.CeilToInt(currentTime);
        speedUpBGM = false;

        UpdateScoreUI();
        UpdateTimerUI();
    }

    private void Update()
    {
        currentTime -= Time.deltaTime;

        int currentSecond = Mathf.CeilToInt(currentTime);

        // 残り10秒でBGM加速（1回だけ）
        if (!speedUpBGM && currentSecond <= 10)
        {
            speedUpBGM = true;
            bgmSource.pitch = 1.2f;
        }

        // 残り10～1秒でカウントダウンSE
        if (currentSecond <= 10 &&
            currentSecond > 0 &&
            currentSecond != lastSecond)
        {
            seSource.PlayOneShot(countdownSE);
        }

        lastSecond = currentSecond;

        if (currentTime <= 0f)
        {
            currentTime = 0f;
            UpdateTimerUI();

            ScoreData.Score = score;

            bgmSource.pitch = 1f;

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