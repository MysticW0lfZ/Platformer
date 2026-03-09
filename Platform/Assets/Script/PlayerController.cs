
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 12f;

    public TextMeshProUGUI healthText;
    public TextMeshProUGUI scoreText;

    private Rigidbody2D rb;
    private bool isGrounded;

    private int health = 100;
    private int score = 0;

    private int totalCoins;
    private int collectedCoins;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        totalCoins = GameObject.FindGameObjectsWithTag("Coin").Length;
        collectedCoins = 0;

        UpdateUI();
    }

    void Update()
    {
        float move = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(move * moveSpeed, rb.velocity.y);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }

        if (collision.gameObject.CompareTag("Enemy"))
        {
            health -= 10;
            UpdateUI();

            if (health <= 0)
            {
                GameOver();
            }
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Coin"))
        {
            collectedCoins++;
            score += 10;

            Debug.Log("Coin collected. Score: " + score);

            Destroy(other.gameObject);
            UpdateUI();

            if (collectedCoins >= totalCoins)
            {
                WinGame();
            }
        }
    }

    void UpdateUI()
    {
        healthText.text = "Health: " + health;
        scoreText.text = "Score: " + score;
    }

    void GameOver()
    {
        PlayerPrefs.SetInt("FinalScore", score);
        PlayerPrefs.SetString("GameResult", "Game Over");
        PlayerPrefs.Save();

        SceneManager.LoadScene("GameOver");
    }

    void WinGame()
    {
        PlayerPrefs.SetInt("FinalScore", score);
        PlayerPrefs.SetString("GameResult", "You Win!");
        PlayerPrefs.Save();

        SceneManager.LoadScene("GameOver");
    }
}