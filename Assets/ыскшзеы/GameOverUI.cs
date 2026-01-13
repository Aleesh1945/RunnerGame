using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOverUI : MonoBehaviour
{
    public GameObject panel;
    public TextMeshProUGUI scoreText;

    void Start()
    {
        panel.SetActive(false);
    }

    public void ShowGameOver()
    {
        panel.SetActive(true);

        float time = GameTimer.Instance.GetTime();
        scoreText.text = $"Time: {time:F2} s";

        Time.timeScale = 0f; // останавливаем игру
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
