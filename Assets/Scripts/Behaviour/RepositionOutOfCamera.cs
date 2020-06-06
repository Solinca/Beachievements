using System.Collections;
using UnityEngine;

public class RepositionOutOfCamera : MonoBehaviour
{
    public Renderer player;

    private void OnBecameInvisible()
    {
        if (gameObject.activeSelf == true)
        {
           StartCoroutine(RespawnAfterSomeTime());
        }
    }

    private IEnumerator RespawnAfterSomeTime()
    {
        yield return new WaitForSeconds(0.5f);

        if (player.isVisible == false)
        {
            transform.position = RespawnCollision.GetCurrentRespawnPosition();
        }
    }
}
