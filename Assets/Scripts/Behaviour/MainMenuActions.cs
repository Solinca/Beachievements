using UnityEngine;

public class MainMenuActions : MonoBehaviour
{
    public void StartGame()
    {
        if (SceneTransitionManager.Instance)
        {
            SceneTransitionManager.Instance.MoveToNextScene();
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
