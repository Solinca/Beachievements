using UnityEngine;

public class SpringCollision : MonoBehaviour
{
    public Animator animator;
    public AudioSource audioSource;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            animator.SetTrigger("Pressed");
            audioSource.Play();
        }
    }
}
