using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private readonly float speed = 0.15f;
    private readonly float jumpSpeed = 800f;
    private float input;
    private bool jumping = false;
    private Rigidbody2D playerRigidbody;
    private SpriteRenderer sprite;

    private void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        input = Input.GetAxis("Horizontal");
            
        if (!jumping && Input.GetButtonDown("Jump"))
        {
            jumping = true;
            playerRigidbody.velocity = Vector2.zero;
            playerRigidbody.AddForce(Vector2.up * jumpSpeed);
        }

        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            sprite.flipX = true;
        } else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            sprite.flipX = false;
        }
    }

    private void FixedUpdate()
    {
        playerRigidbody.transform.Translate(new Vector2(input * speed, 0));
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (jumping && playerRigidbody.velocity == Vector2.zero)
        {
            jumping = false;
        }
    }
}
