using TMPro;
using UnityEngine;

public class EmeraldManager : MonoBehaviour
{
    public static EmeraldManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        } else
        {
            Destroy(gameObject);
        }
    }

    public Transform emeraldContainer;
    public TextMeshProUGUI emeraldObtainedText;
    public TextMeshProUGUI emeraldTotalText;

    private int emeraldObtained = 0;
    private int emeraldTotal = 0;

    private void Start()
    {
        emeraldTotal = emeraldContainer.childCount;
        emeraldTotalText.SetText(emeraldTotal.ToString());
    }

    public void CollectEmerald()
    {
        emeraldObtained++;
        emeraldObtainedText.SetText(emeraldObtained.ToString());

        if (emeraldObtained == emeraldTotal)
        {
            AchievementManager.Instance.CollectAchievement("EmeraldCollector");
        }
    }
}
