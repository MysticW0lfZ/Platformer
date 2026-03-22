using UnityEngine;

public class Coin : MonoBehaviour
{
    private bool collected = false;

    void OnEnable()
    {
        collected = false; // reset when reused from pool
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (collected) return;

        if (other.CompareTag("Player"))
        {
            collected = true;

            GameManager.Instance.AddScore(10);
            GameManager.Instance.CoinCollected();

            ObjectPool.Instance.Return(gameObject);
        }
    }
}