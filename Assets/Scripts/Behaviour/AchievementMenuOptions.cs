using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AchievementMenuOptions : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject achievementMenu;
    public GameObject achievementTemplate;
    public GameObject container;
    public RectTransform containerRectTransform;
    public Sprite defaultSprite;

    private readonly float templateHeight = 100f;
    private readonly float margin = 5f;
    private Dictionary<int, GameObject> displayedOrder = new Dictionary<int, GameObject>();
    private bool init = false;

    public void OpenAchievementMenu()
    {
        mainMenu.SetActive(false);
        achievementMenu.SetActive(true);

        if (init)
        {
            UpdateEveryAchievement();
        } else
        {
            LoadEveryAchievement();
        }
    }

    public void PreviousMenu()
    {
        mainMenu.SetActive(true);
        achievementMenu.SetActive(false);
    }

    private void UpdateEveryAchievement()
    {
        if (!AchievementManager.Instance)
        {
            return;
        }

        Dictionary<string, Achievement> achievements = AchievementManager.Instance.GetAllAchievements();

        foreach (KeyValuePair<string, Achievement> achievement in achievements)
        {
            if (achievement.Value.collected)
            {
                SetUI(displayedOrder[achievement.Value.order].transform, achievement.Value.sprite, achievement.Value.title, achievement.Value.description);
            } else
            {
                SetUI(displayedOrder[achievement.Value.order].transform, defaultSprite, achievement.Value.title, achievement.Value.hint);
            }
        }
    }

    private void LoadEveryAchievement()
    {
        if (!AchievementManager.Instance)
        {
            return;
        } else
        {
            init = true;
        }

        Dictionary<string, Achievement> achievements = AchievementManager.Instance.GetAllAchievements();

        containerRectTransform.offsetMin = new Vector2(containerRectTransform.offsetMin.x, - achievements.Count * templateHeight);

        foreach (KeyValuePair<string, Achievement> achievement in achievements)
        {
            GameObject achievementObject = Instantiate(achievementTemplate, container.transform);
            RectTransform newEntryTransform = achievementObject.GetComponent<RectTransform>();
            newEntryTransform.anchoredPosition = new Vector2(0, - achievement.Value.order * templateHeight + margin);

            displayedOrder.Add(achievement.Value.order, achievementObject);

            if (achievement.Value.collected)
            {
                SetUI(achievementObject.transform, achievement.Value.sprite, achievement.Value.title, achievement.Value.description);
            } else
            {
                SetUI(achievementObject.transform, defaultSprite, achievement.Value.title, achievement.Value.hint);
            }
        }
    }

    private void SetUI(Transform achievement, Sprite sprite, string title, string description)
    {
        achievement.Find("Image").GetComponent<Image>().sprite = sprite;
        achievement.Find("Title").GetComponent<TextMeshProUGUI>().SetText(title);
        achievement.Find("Description").GetComponent<TextMeshProUGUI>().SetText(description);
    }
}
