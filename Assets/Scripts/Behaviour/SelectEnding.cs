using TMPro;
using UnityEngine;
using System.Collections.Generic;

public class SelectEnding : MonoBehaviour
{
    public GameObject win;
    public GameObject loss;
    public TextMeshProUGUI achievementCounter;

    private void Start()
    {
        if (AchievementManager.Instance)
        {
            Dictionary<string, Achievement> achievements = AchievementManager.Instance.GetAllAchievements();

            int maxAchievements = achievements.Count;
            int achievementObtained = 0;

            foreach (KeyValuePair<string, Achievement> achievement in achievements)
            {
                if (achievement.Value.collected)
                {
                    achievementObtained++;
                }
            }

            achievementCounter.SetText(achievementObtained + " / " + maxAchievements + " achievements");

            if (achievementObtained == maxAchievements)
            {
                win.SetActive(true);
            } else
            {
                loss.SetActive(true);
            }
        }
    }
}
