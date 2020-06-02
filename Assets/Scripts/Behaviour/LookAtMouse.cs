using UnityEngine;

public class LookAtMouse : MonoBehaviour
{
    public RectTransform myTransform;
    public Transform anchorPosition;

    private readonly float eyeWidth = 30f;
    private readonly float eyeheight = 10f;

    private void FixedUpdate()
    {
        var mousePosition = Input.mousePosition;
        float newXPos = mousePosition.x - anchorPosition.position.x > 0 ? Mathf.Min((mousePosition.x - anchorPosition.position.x) / 2, eyeWidth) : 0;
        float newYPos = mousePosition.y - anchorPosition.position.y > 0 ? Mathf.Min((mousePosition.y - anchorPosition.position.y) / 5, eyeheight) : 0;
        myTransform.offsetMin = new Vector2(newXPos, newYPos);
        myTransform.offsetMax = new Vector2(newXPos - eyeWidth, newYPos - eyeheight);
    }
}
