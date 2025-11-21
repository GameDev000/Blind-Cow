using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [Header("Runners")]
    [SerializeField] private int totalRunners;
    private int caughtRunners = 0;

    [Header("UI Screens")]
    [SerializeField] private GameObject winnerScreen;
    [SerializeField] private GameObject looserScreen;

    [Header("Timer")]
    [SerializeField] private float roundTime = 60f;
    [SerializeField] private TextMeshProUGUI timerText;
    private bool isGameOver = false;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        totalRunners = FindObjectsByType<runner>(FindObjectsSortMode.None).Length;

        if (winnerScreen != null)
            winnerScreen.SetActive(false);
        if (looserScreen != null)
            looserScreen.SetActive(false);

        UpdateTimerText();
    }

    private void Update()
    {
        if (isGameOver)
            return;
        roundTime -= Time.deltaTime;
        if (roundTime < 0f)
            roundTime = 0f;

        UpdateTimerText();

        if (roundTime <= 0f && caughtRunners < totalRunners)
        {
            ShowLoserScreen();
        }
    }
    private void UpdateTimerText()
    {
        if (timerText == null)
            return;

        int seconds = Mathf.CeilToInt(roundTime);
        int minutes = seconds / 60;
        int sec = seconds % 60;

        timerText.text = $"{minutes:00}:{sec:00}";
    }
    public void OnRunnerCaught(runner r)
    {
        caughtRunners++;
        if (caughtRunners >= totalRunners)
        {
            Debug.Log("ALL RUNNERS CAUGHT — YOU WIN!");
            ShowWinnerScreen();
        }
    }
    private void ShowWinnerScreen()
    {
        if (winnerScreen != null)
            winnerScreen.SetActive(true);
    }
    private void ShowLoserScreen()
    {
        if (looserScreen != null)
            looserScreen.SetActive(true);
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
