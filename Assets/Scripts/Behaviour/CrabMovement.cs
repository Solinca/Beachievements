using UnityEngine;

public class CrabMovement : MonoBehaviour
{
    private readonly float speed = 0.05f;
    private float direction = 1f;
    private Vector3 lastpos;

    private void FixedUpdate()
    {
        transform.Translate(new Vector2(speed * direction, 0));

        if (lastpos == transform.position)
        {
            direction *= -1f;
        }

        lastpos = transform.position;
    }
}
