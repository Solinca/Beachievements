using UnityEngine;

public class ExitScene : MonoBehaviour
{
    private bool hasExited = false;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Exit" && !hasExited)
        {
            if (SceneTransitionManager.Instance)
            {
                SceneTransitionManager.Instance.MoveToNextScene();
            }

            hasExited = true;
        }
    }
}
