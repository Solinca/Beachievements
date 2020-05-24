using UnityEngine;

public class SpringBounce : MonoBehaviour
{
    public Animator animator;
    public AudioSource audioSource;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Spring")
        {
            animator.SetTrigger("Pressed");
            audioSource.Play();
        }
    }
}
