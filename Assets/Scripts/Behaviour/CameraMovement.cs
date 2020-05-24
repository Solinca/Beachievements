using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform target;
    public float minX = 0;
    public float minY = 0;

    private readonly float cameraSpeed = 0.3f;
    private readonly float offsetZ = -1;
    private Vector3 velocity = Vector3.zero;

    private void FixedUpdate()
    {
        Vector3 desiredPosition = new Vector3(Mathf.Max(target.position.x, minX), Mathf.Max(target.position.y, minY), offsetZ);
        transform.position = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, cameraSpeed);
    }
}
