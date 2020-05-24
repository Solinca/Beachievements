using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneTransitionManager : MonoBehaviour
{
    public static SceneTransitionManager Instance { get; private set; }

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
    }
    
    public Animator endSceneAnimation;

    public AudioSource audioStart;
    public AudioSource audioEnd;
    public AudioSource tutorialAudio;

    public void MoveToNextScene()
    {
        endSceneAnimation.SetBool("next_scene", true);

        tutorialAudio.Stop();
        audioStart.Play();

        StartCoroutine("LoadNextScene");
    }

    private IEnumerator LoadNextScene()
    {
        yield return new WaitForSeconds(2f);

        AsyncOperation changeScene = SceneManager.LoadSceneAsync(1);

        yield return new WaitForSeconds(0.5f);

        endSceneAnimation.SetBool("next_scene", false);

        audioEnd.Play();

        yield return new WaitForSeconds(1f);

        AchievementManager.Instance.DisplayAchievement("Tutorial");
    }
}
