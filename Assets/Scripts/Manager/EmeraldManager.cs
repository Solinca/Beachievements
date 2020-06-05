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
    private int emeraldTotal;

    private void Start()
    {
        emeraldTotalText.SetText((emeraldTotal = emeraldContainer.childCount).ToString());
    }

    public void CollectEmerald()
    {
        emeraldObtainedText.SetText((++emeraldObtained).ToString());

        if (emeraldObtained == emeraldTotal)
        {
            AchievementManager.Instance.CollectAchievement("EmeraldCollector");
        }
    }
}
