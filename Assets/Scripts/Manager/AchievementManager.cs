using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AchievementManager : MonoBehaviour
{
    public static AchievementManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        } else
        {
            Destroy(gameObject);
        }

        Object[] achievementList = Resources.LoadAll("ScriptableObjects/Achievements");

        achievementDictionnary = achievementList.ToDictionary(x => x.name, x => (Achievement) x);
    }

    private void Start()
    {
        DisplayAchievement("Tutorial");
    }

    public Image achievementImage;
    public TextMeshProUGUI achievementTitleText;
    public TextMeshProUGUI achievementDescriptionText;

    public Animator animator;
    public bool processing = false;

    private Dictionary<string, Achievement> achievementDictionnary;
    private Queue<string> queuedAchievements = new Queue<string>();
    private List<string> collectedAchievements = new List<string>();

    public void CollectAchievement(string name)
    {
        collectedAchievements.Add(name);
        DisplayAchievement(name);
    }

    public bool IsCollected(string name)
    {
        return collectedAchievements.Contains(name);
    }

    private void DisplayAchievement(string name)
    {
        if (processing)
        {
            queuedAchievements.Enqueue(name);
        } else
        {
            Achievement achievement = RetrieveAchievement(name);

            if (achievement == null)
            {
                return;
            }

            UpdateUI(achievement);
            animator.SetTrigger("opened");
        }
    }

    private void UpdateUI(Achievement achievement)
    {
        achievementImage.sprite = achievement.sprite;
        achievementTitleText.SetText(achievement.title);
        achievementDescriptionText.SetText(achievement.descritpion);
    }

    private Achievement RetrieveAchievement(string name)
    {
        return achievementDictionnary.ContainsKey(name) ? achievementDictionnary[name] : null;
    }

    public void ProcessNextQueue()
    {
        processing = false;

        if (queuedAchievements.Count > 0)
        {
            DisplayAchievement(queuedAchievements.Dequeue());
        }
    }
}
