using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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
    public AudioMixer audioMixer;
    public Slider musicSlider;
    public Slider effectSlider;

    public bool IsOpened()
    {
        return gameObject.activeSelf;
    }

    public void OptionsMenu()
    {
        optionsMenu.SetActive(true);
        mainMenu.SetActive(false);

        audioMixer.GetFloat("MusicVolume", out float musicValue);
        audioMixer.GetFloat("EffectVolume", out float effectValue);

        musicSlider.value = musicValue;
        effectSlider.value = effectValue;
    }

    public void SetMusicVolume(float volume)
    {
        audioMixer.SetFloat("MusicVolume", volume);
    }

    public void SetEffectVolume(float volume)
    {
        audioMixer.SetFloat("EffectVolume", volume);
    }

    public void PreviousMenu()
    {
        optionsMenu.SetActive(false);
        mainMenu.SetActive(true);
    }

    public void OpenMenu()
    {
        if (SceneTransitionManager.Instance.IsProcessing())
        {
            return;
        }

        PreviousMenu();
        gameObject.SetActive(true);
        Time.timeScale = 0f;
        Camera.main.GetComponent<AudioSource>().Pause();
    }

    public void ResumeGame()
    {
        gameObject.SetActive(false);
        Time.timeScale = 1f;
        Camera.main.GetComponent<AudioSource>().Play();
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene(0);
        gameObject.SetActive(false);
        Time.timeScale = 1f;
    }
}
