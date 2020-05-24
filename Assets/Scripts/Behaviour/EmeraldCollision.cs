using UnityEngine;

public class EmeraldCollision : MonoBehaviour
{
    public ParticleSystem particles;
    public SpriteRenderer sprite;
    public AudioSource audioSource;

    private bool collided = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player" && !collided)
        {
            collided = true;
            sprite.color = new Color(1, 1, 1, 0);
            audioSource.Play();
            Destroy(gameObject, 1.2f);
            particles.Play();
            EmeraldManager.Instance.CollectEmerald();
        }
    }
}
