using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
  public static GameManager Instance;
    [SerializeField] private int totalRunners;
    private int caughtRunners = 0;
    [SerializeField] private GameObject winnerScreen;
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
    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
