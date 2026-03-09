using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float patrolDistance = 2f;

    private Vector3 startPos;
    private int direction = 1;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        transform.Translate(Vector2.right * direction * moveSpeed * Time.deltaTime);

        float distanceFromStart = transform.position.x - startPos.x;

        if (Mathf.Abs(distanceFromStart) >= patrolDistance)
        {
            direction *= -1;
        }
    }
}