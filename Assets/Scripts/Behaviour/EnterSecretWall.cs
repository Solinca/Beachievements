using UnityEngine;

public class EnterSecretWall : MonoBehaviour
{
    public Animator animator;
    public CameraMovement cameraMovement;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.name == "Secret1Entrance")
        {
            animator.SetBool("Entered", true);
            cameraMovement.minX = -9.12f;
 
            if (!AchievementManager.Instance.IsCollected("HiddenRoom"))
            {
                AchievementManager.Instance.CollectAchievement("HiddenRoom");
            }
        }

        if (collider.gameObject.name == "Secret1Exit")
        {
            animator.SetBool("Entered", false);
            cameraMovement.minX = 0f;
        }
    }
}
