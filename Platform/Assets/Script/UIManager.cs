
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI healthText;

    void OnEnable()
    {
        GameManager.Instance.onScoreChanged += UpdateScore;
        GameManager.Instance.onHealthChanged += UpdateHealth;
        GameManager.Instance.onGameOver += HandleGameOver;
    }

    void OnDisable()
    {
        GameManager.Instance.onScoreChanged -= UpdateScore;
        GameManager.Instance.onHealthChanged -= UpdateHealth;
        GameManager.Instance.onGameOver -= HandleGameOver;
    }

    void UpdateScore(int newScore)
    {
        scoreText.text = "Score: " + newScore;
    }

    void UpdateHealth(int newHealth)
    {
        healthText.text = "Health: " + newHealth;
    }

    void HandleGameOver()
    {
        SceneManager.LoadScene("GameOver");
    }
}