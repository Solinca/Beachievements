using UnityEngine;

public class GetAchievement : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.layer == LayerMask.NameToLayer("Achievement") && AchievementManager.Instance)
        {
            AchievementManager.Instance.CollectAchievement(collider.gameObject.name);
        }
    }
}
