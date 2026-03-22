
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    void Start()
    {
        int finalScore = GameManager.Instance.GetScore();
        Debug.Log("Final Score: " + finalScore);

        scoreText.text = "Final Score: " + finalScore;
    }

    public void RestartGame()
    {
        GameManager.Instance.ResetGame();
        SceneManager.LoadScene("GameScene");
    }
}