using UnityEngine;

public class GetBounceAchievement : MonoBehaviour
{
    private bool collided = false;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.name == "BounceAchievement" && !collided)
        {
            collided = true;
            AchievementManager.Instance.DisplayAchievement("BounceKing");
        }
    }
}
