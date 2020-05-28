using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MainMenuAction : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject optionsMenu;
    public AudioMixer audioMixer;
    public Slider musicSlider;
    public Slider effectSlider;

    public void StartGame()
    {
        SceneTransitionManager.Instance.MoveToNextScene();
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

    public void QuitGame()
    {
        Application.Quit();
    }
}
