using UnityEngine;

public class AlignWithCamera : MonoBehaviour
{
    public Transform anchor;
    public Camera mainCamera;

    private Vector2 lastScreenSize;

    private void Awake()
    {
        Align();
        lastScreenSize = GetScreenSize();
    }

    private void Update()
    {
        Vector2 screenSize = GetScreenSize();

        if (this.lastScreenSize != screenSize)
        {
            this.lastScreenSize = screenSize;
            Align();
        }
    }

    private Vector2 GetScreenSize()
    {
        return new Vector2(Screen.width, Screen.height);
    }

    private void Align()
    {
        float halfWidth = mainCamera.aspect * mainCamera.orthographicSize;
        transform.position = new Vector2(-(anchor.position.x + halfWidth), transform.position.y);
    }
}
