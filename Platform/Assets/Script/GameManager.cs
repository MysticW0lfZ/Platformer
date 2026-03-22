using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public event Action<int> onScoreChanged;
    public event Action<int> onHealthChanged;
    public event Action onGameOver;

    private int score = 0;
    private int health = 100;
    private int coinsRemaining;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "GameScene")
        {
            coinsRemaining = GameObject.FindGameObjectsWithTag("Coin").Length;
            Debug.Log("Coins Reset: " + coinsRemaining);
        }
    }

    public void AddScore(int points)
    {
        score += points;
        Debug.Log("Score Updated: " + score);
        onScoreChanged?.Invoke(score);
    }

    public void CoinCollected()
    {
        coinsRemaining--;
        Debug.Log("Coins left: " + coinsRemaining);

        if (coinsRemaining <= 0)
        {
            Debug.Log("YOU WIN");
            onGameOver?.Invoke();
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        Debug.Log("Health Updated: " + health);

        onHealthChanged?.Invoke(health);

        if (health <= 0)
        {
            onGameOver?.Invoke();
        }
    }

    public int GetScore()
    {
        return score;
    }

    public void ResetGame()
    {
        score = 0;
        health = 100;

        onScoreChanged?.Invoke(score);
        onHealthChanged?.Invoke(health);
    }
}