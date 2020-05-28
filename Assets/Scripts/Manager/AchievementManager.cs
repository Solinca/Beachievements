using System.Collections;
using System.Collections.Generic;
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

        achievementList = Resources.LoadAll("ScriptableObjects/Achievements");
    }

    private void Start()
    {
        DisplayAchievement("Tutorial");
    }

    public AudioSource audioSource;
    public Image achievementImage;
    public RectTransform achievementContainer;
    public TextMeshProUGUI achievementTitleText;
    public TextMeshProUGUI achievementDescriptionText;

    private bool opening = false;
    private bool processing = false;
    private Object[] achievementList;
    private List<string> queuedAchievements = new List<string>();
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
            queuedAchievements.Add(name);
        } else
        {
            Achievement achievement = RetrieveAchievement(name);

            if (achievement == null)
            {
                return;
            }

            UpdateUI(achievement);
            opening = processing = true;
            audioSource.Play();
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
        foreach (Achievement achievement in achievementList)
        {
            if (achievement.name == name)
            {
                return achievement;
            }
        }

        return null;
    }

    private void FixedUpdate()
    {
        if (opening)
        {
            achievementContainer.Translate(Vector2.up * 2.5f * Time.deltaTime);

            if (achievementContainer.anchoredPosition.y >= -2.5f)
            {
                opening = false;
                StartCoroutine("CloseWindow");
            }
        }
    }

    private IEnumerator CloseWindow()
    {
        yield return new WaitForSeconds(5f);

        while (achievementContainer.anchoredPosition.y >= -76f)
        {
            achievementContainer.Translate(Vector2.down * 2.5f * Time.deltaTime);
            yield return new WaitForSeconds(Time.deltaTime);
        }

        processing = false;

        if (queuedAchievements.Count > 0)
        {
            DisplayAchievement(queuedAchievements[0]);
            queuedAchievements.RemoveAt(0);
        }
    }
}
