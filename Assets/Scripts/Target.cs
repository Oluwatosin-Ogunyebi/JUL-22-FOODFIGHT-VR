using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Target : MonoBehaviour
{
    public Collider spawnArea;
    public float destroyDelay;
    private void OnCollisionEnter(Collision collision)
    {
        var foodCollidedWIth = collision.gameObject.GetComponent<XRGrabInteractable>();
        if (foodCollidedWIth != null)
        {
            Destroy(collision.gameObject, destroyDelay);
            ChangeTargetPosition(spawnArea);
        }
    }

    void ChangeTargetPosition(Collider area)
    {
        float x = Random.Range(area.bounds.min.x, area.bounds.max.x);
        float y = Random.Range(area.bounds.min.y, area.bounds.max.y);
        float z = Random.Range(area.bounds.min.z, area.bounds.max.z);

        transform.position = new Vector3(x, y, z);
    }
}
