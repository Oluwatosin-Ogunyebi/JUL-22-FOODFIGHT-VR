using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

[RequireComponent(typeof(AudioSource))]
public class Target : MonoBehaviour
{
    public Collider spawnArea;
    public float destroyDelay;


    AudioSource audioSource;
    public AudioClip targetHitSound;

    private void Awake()
    {
        audioSource = this.GetComponent<AudioSource>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("FoodItem") && GameManager.Instance.checkIsGameRunning())
        {
            audioSource.PlayOneShot(targetHitSound);
            Destroy(collision.gameObject, destroyDelay);
            ChangeTargetPosition(spawnArea);

            GameManager.Instance.AddScore();
            GameManager.Instance.SpawnFoodItems();
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
