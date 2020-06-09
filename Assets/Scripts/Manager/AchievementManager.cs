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
            DontDestroyOnLoad(gameObject);
        } else
        {
            Destroy(gameObject);
        }

        Object[] achievementList = Resources.LoadAll("ScriptableObjects/Achievements");

        achievementDictionnary = achievementList.ToDictionary(x => x.name, x => {
            Achievement achievement = (Achievement) x;
            achievement.collected = false;
            return achievement;
        });
    }

    public Image achievementImage;
    public TextMeshProUGUI achievementTitleText;
    public TextMeshProUGUI achievementDescriptionText;

    public Animator animator;
    public bool processing = false;

    private Dictionary<string, Achievement> achievementDictionnary;
    private Queue<string> queuedAchievements = new Queue<string>();

    public void CollectAchievement(string name)
    {
        if (IsCollected(name))
        {
            return;
        }

        AddToCollection(name);
        DisplayAchievement(name);
    }

    private bool IsCollected(string name)
    {
        return achievementDictionnary.ContainsKey(name) ? achievementDictionnary[name].collected : false;
    }

    public Dictionary<string, Achievement> GetAllAchievements()
    {
        return achievementDictionnary;
    }

    private void AddToCollection(string name)
    {
        if (achievementDictionnary.ContainsKey(name))
        {
            achievementDictionnary[name].collected = true;
        }
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
        achievementDescriptionText.SetText(achievement.description);
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
