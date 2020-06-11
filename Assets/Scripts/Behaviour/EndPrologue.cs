using UnityEngine;
using UnityEngine.SceneManagement;

public class EndPrologue : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
