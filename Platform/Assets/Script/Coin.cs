
using UnityEngine;

public class Coin : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Coin collected");

            GameManager.Instance.AddScore(10);
            GameManager.Instance.CoinCollected();

            Destroy(gameObject);
        }
    }
}