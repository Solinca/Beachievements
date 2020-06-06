using UnityEngine;

public class RespawnCollision : MonoBehaviour
{
    private static GameObject currentRespawn;
    private static Vector3 startingPoint;

    private void Start()
    {
        startingPoint = transform.position;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.layer == LayerMask.NameToLayer("Respawn"))
        {
            SaveNewRespawn(collider.gameObject);
        }
    }

    public static Vector3 GetCurrentRespawnPosition()
    {
        if (currentRespawn == null)
        {
            return startingPoint;
        } else
        {
            return currentRespawn.transform.position;
        }
    }

    private void SaveNewRespawn(GameObject respawn)
    {
        if (currentRespawn != respawn)
        {
            ToggleRespawn(false);
            currentRespawn = respawn;
            ToggleRespawn(true);
        }
    }

    private void ToggleRespawn(bool isCheck)
    {
        if (currentRespawn != null)
        {
            currentRespawn.GetComponent<Animator>().SetBool("checked", isCheck);
        }
    }
}
