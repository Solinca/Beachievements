using UnityEngine;

public class ExitTutorial : MonoBehaviour
{
    private bool hasExited = false;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Exit" && !hasExited)
        {
            SceneTransitionManager.Instance.MoveToNextScene();
            hasExited = true;
        }
    }
}
