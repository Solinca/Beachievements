using UnityEngine;

public class OpenMenu : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && PauseMenuManager.Instance)
        {
            if (PauseMenuManager.Instance.IsOpened())
            {
                PauseMenuManager.Instance.ResumeGame();
            } else
            {
                PauseMenuManager.Instance.OpenMenu();
            }
        }
    }
}
