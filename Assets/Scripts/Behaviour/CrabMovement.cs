using UnityEngine;

public class CrabMovement : MonoBehaviour
{
    private readonly float speed = 0.05f;
    private float direction = 1f;

    private void FixedUpdate()
    {
        transform.position = new Vector2(transform.position.x + speed * direction, transform.position.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name != "Player")
        {
            direction *= -1f;
        }
    }
}
