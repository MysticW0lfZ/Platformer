
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    void Start()
    {
        if (GameManager.Instance != null)
        {
            int finalScore = GameManager.Instance.GetScore();
            Debug.Log("Final Score: " + finalScore);

            scoreText.text = "Final Score: " + finalScore;
        }
    }

    public void RestartGame()
    {
        Debug.Log("Restart Clicked");

        if (GameManager.Instance != null)
        {
            GameManager.Instance.ResetGame();
        }

        SceneManager.LoadScene("GameScene");
    }
}