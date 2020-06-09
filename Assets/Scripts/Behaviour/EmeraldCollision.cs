using UnityEngine;

public class EmeraldCollision : MonoBehaviour
{
    public Animator animator;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.name == "Player")
        {
            animator.SetBool("collected", true);

            if (EmeraldManager.Instance)
            {
                EmeraldManager.Instance.CollectEmerald();
            }
        }
    }
}
