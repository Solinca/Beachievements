using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class OptionsMenuActions : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject optionsMenu;
    public AudioMixer audioMixer;
    public Slider musicSlider;
    public Slider effectSlider;

    public void OpenOptionsMenu()
    {
        mainMenu.SetActive(false);
        optionsMenu.SetActive(true);

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
        mainMenu.SetActive(true);
        optionsMenu.SetActive(false);
    }
}
