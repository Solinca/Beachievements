using UnityEngine;

public class GetHeightAchievement : MonoBehaviour
{
    private bool collided = false;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.name == "HeightAchievement" && !collided)
        {
            collided = true;
            AchievementManager.Instance.DisplayAchievement("NewHeight");
        }
    }
}
