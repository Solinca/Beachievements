using System.Collections;
using UnityEngine;

public class MovePlatform : MonoBehaviour
{
    public Vector3 velocity = Vector2.right;
    public float speed = 0.1f;
    public float time = 2f;

    private float direction = 1f;

    private void Start()
    {
        StartCoroutine(ChangeDirection());
    }

    private void FixedUpdate()
    {
        transform.position += velocity * speed * direction;
    }

    private IEnumerator ChangeDirection()
    {
        while(true)
        {
            yield return new WaitForSeconds(time);

            direction *= -1f;
        }
    }
}
