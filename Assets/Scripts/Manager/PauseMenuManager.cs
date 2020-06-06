using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuManager : MonoBehaviour
{
    public static PauseMenuManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            gameObject.SetActive(false);
            DontDestroyOnLoad(gameObject);
        } else
        {
            Destroy(gameObject);
        }
    }

    public GameObject mainMenu;
    public GameObject optionsMenu;

    public bool IsOpened()
    {
        return gameObject.activeSelf;
    }

    public void OpenMenu()
    {
        if (SceneTransitionManager.Instance.IsProcessing())
        {
            return;
        }

        gameObject.SetActive(true);
        mainMenu.SetActive(true);
        optionsMenu.SetActive(false);
        Time.timeScale = 0f;
        Camera.main.GetComponent<AudioSource>().Pause();
    }

    public void ResumeGame()
    {
        ResumeTime();
        Camera.main.GetComponent<AudioSource>().Play();
    }

    public void ReturnToMainMenu()
    {
        ResumeTime();
        SceneManager.LoadScene(0);
    }

    private void ResumeTime()
    {
        gameObject.SetActive(false);
        Time.timeScale = 1f;
    }
}
