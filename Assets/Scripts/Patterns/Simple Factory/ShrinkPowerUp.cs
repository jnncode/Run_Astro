using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShrinkPowerUp : MonoBehaviour, IPowerUp
{
    private float shrinkFactor = 0.5f; 
    private Vector3 position;
    private GameObject powerUpObject;

    public void Activate(AstronautPlayer astronautPlayer)
    {
        float colliderHeight = astronautPlayer.controller.height;
        float shrunkHeight = astronautPlayer.transform.localScale.y * colliderHeight * shrinkFactor;
        Vector3 colliderCenter = astronautPlayer.controller.center;
        float newColliderCenterY = -shrunkHeight / 2.0f + colliderHeight / 2.0f;
        Vector3 newColliderCenter = new Vector3(colliderCenter.x, newColliderCenterY, colliderCenter.z);
        Vector3 positionOffset = new Vector3(0, (shrunkHeight - colliderHeight) / 2.0f, 0);
        astronautPlayer.controller.center = newColliderCenter;
        astronautPlayer.transform.position += positionOffset;
        astronautPlayer.transform.localScale *= shrinkFactor;

        // ensure the player remains grounded
        RaycastHit hitInfo;
        if (Physics.Raycast(astronautPlayer.transform.position, Vector3.down, out hitInfo, Mathf.Infinity))
        {
            astronautPlayer.transform.position = hitInfo.point + new Vector3(0, colliderHeight / 2.0f, 0);
        }
    }

    public void SetPosition(Vector3 position)
    {
        this.position = position;
    }

    public void PlaySpawnAnimation()
    {
        StartCoroutine(SpawnAnimationCoroutine());
    }

    private IEnumerator SpawnAnimationCoroutine()
    {
        float duration = 0.5f;
        float timeElapsed = 0.0f;
        Vector3 initialScale = Vector3.zero;

        while (timeElapsed < duration)
        {
            timeElapsed += Time.deltaTime;
            float t = Mathf.Clamp01(timeElapsed / duration);
            Vector3 newScale = Vector3.Lerp(initialScale, Vector3.one / shrinkFactor, t);
            powerUpObject.transform.localScale = newScale;
            yield return null;
        }
    }
}
