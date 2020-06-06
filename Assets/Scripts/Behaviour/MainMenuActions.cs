using UnityEngine;

public class MainMenuActions : MonoBehaviour
{
    public void StartGame()
    {
        SceneTransitionManager.Instance.MoveToNextScene();
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
