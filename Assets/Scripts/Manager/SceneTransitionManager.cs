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
    public CanvasGroup canvasGroup;

    private SceneTransitionState transitioning = SceneTransitionState.None;

    public bool IsTransitioning()
    {
        return transitioning != SceneTransitionState.None;
    }

    public SceneTransitionState GetTransitionState()
    {
        return transitioning;
    }

    public void MoveToNextScene()
    {
        endSceneAnimation.SetBool("next_scene", true);

        canvasGroup.blocksRaycasts = true;

        Camera.main.GetComponent<AudioSource>().Stop();
 
        audioStart.Play();

        transitioning = SceneTransitionState.Start;

        StartCoroutine("LoadNextScene");
    }

    private IEnumerator LoadNextScene()
    {
        yield return new WaitForSeconds(3f);

        AsyncOperation changeScene = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);

        yield return new WaitForSeconds(0.3f);

        endSceneAnimation.SetBool("next_scene", false);

        canvasGroup.blocksRaycasts = false;

        transitioning = SceneTransitionState.End;

        audioEnd.Play();

        yield return new WaitForSeconds(1f);

        transitioning = SceneTransitionState.None;
    }
}

public enum SceneTransitionState
{
    None,
    Start,
    End
}
