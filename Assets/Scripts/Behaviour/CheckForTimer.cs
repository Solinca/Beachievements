using UnityEngine;

public class CheckForTimer : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            TimerCountdown.stopTimer = true;

            if (AchievementManager.Instance && TimerCountdown.IsLessThan3Minutes())
            {
                AchievementManager.Instance.CollectAchievement("Speedrun");
            }
        }
    }
}
