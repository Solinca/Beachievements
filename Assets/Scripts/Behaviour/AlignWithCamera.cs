using UnityEngine;

public class AlignWithCamera : MonoBehaviour
{
    public Transform anchor;
    public Camera mainCamera;

    private Vector2 lastScreenSize;

    private void Awake()
    {
        Align();
        lastScreenSize = new Vector2(Screen.width, Screen.height);
    }

    private void Update()
    {
        Vector2 screenSize = new Vector2(Screen.width, Screen.height);

        if (this.lastScreenSize != screenSize)
        {
            this.lastScreenSize = screenSize;
            Align();
        }
    }

    private void Align()
    {
        float halfWidth = mainCamera.aspect * mainCamera.orthographicSize;
        transform.position = new Vector2(-(anchor.position.x + halfWidth), transform.position.y);
    }
}
