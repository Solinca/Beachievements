using UnityEngine;

public class EnterSecretWall : MonoBehaviour
{
    public GameObject wall;
    public Camera cameraMovement;

    private CameraMovement script;
    private Renderer wallRenderer;
    private bool fading = false;
    private float fadeTo;
    private float spendTime = 0;
    private bool gotAchievement = false;

    private void Start()
    {
        script = cameraMovement.GetComponent<CameraMovement>();
        wallRenderer = wall.GetComponent<Renderer>();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.name == "Secret1Entrance")
        {
            fading = true;
            spendTime = 0;
            fadeTo = 0;
            script.minX = -9.12f;
 
            if (!gotAchievement)
            {
                AchievementManager.Instance.DisplayAchievement("HiddenRoom");
                gotAchievement = true;
            }
        }

        if (collider.gameObject.name == "Secret1Exit")
        {
            fading = true;
            spendTime = 0;
            fadeTo = 1;
            script.minX = 0;
        }
    }

    private void FixedUpdate()
    {
        if (fading)
        {
            float time = Mathf.Lerp(wallRenderer.material.color.a, fadeTo, spendTime);
            wallRenderer.material.color = new Color(wallRenderer.material.color.r, wallRenderer.material.color.g, wallRenderer.material.color.b, time);
            spendTime += Time.deltaTime;

            if (spendTime >= 1)
            {
                fading = false;
            }
        }
    }
}
