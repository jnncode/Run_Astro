using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpandPowerUp : MonoBehaviour, IPowerUp
{
    private float expandFactor = 1.5f;
    private Vector3 position;
    private GameObject powerUpObject;
    public void Activate(AstronautPlayer astronautPlayer) {
        float colliderHeight = astronautPlayer.controller.height;
        float expandedHeight = astronautPlayer.transform.localScale.y * colliderHeight;
        Vector3 colliderCenter = astronautPlayer.controller.center;
        float newColliderCenterY = -expandedHeight / 2.0f + colliderHeight / 2.0f;
        Vector3 newColliderCenter = new Vector3(colliderCenter.x, newColliderCenterY, colliderCenter.z);
        Vector3 positionOffset = new Vector3(0, (expandedHeight - colliderHeight) / 2.0f, 0);
        astronautPlayer.controller.center = newColliderCenter;
        astronautPlayer.transform.position += positionOffset;
        astronautPlayer.transform.localScale *= expandFactor;

        // adjust player position to account for new collider size
        float newColliderHeight = astronautPlayer.controller.height;
        float heightDiff = newColliderHeight - colliderHeight;
        Vector3 newPosition = astronautPlayer.transform.position - new Vector3(0, heightDiff / 2.0f, 0);

        // check if player is floating
        RaycastHit hit;
        if (Physics.Raycast(newPosition, Vector3.down, out hit, 100f))
        {
            // move player down to ground level
            float groundHeight = hit.point.y;
            float playerHeight = newPosition.y;
            float delta = groundHeight - playerHeight;
            newPosition += new Vector3(0, delta, 0);
        }
        astronautPlayer.transform.position = newPosition;
    }

    public void SetPosition(Vector3 position) {
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
            Vector3 newScale = Vector3.Lerp(initialScale, Vector3.one, t);
            powerUpObject.transform.localScale = newScale;
            yield return null;
        }
    }
}
