using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodItem : MonoBehaviour
{
    public void DestroyAfterDelay(int time)
    {
        Invoke("SpawnNewFoodItem", time);
        Destroy(this.gameObject, time);
    }

    void SpawnNewFoodItem()
    {
        GameManager.Instance.SpawnFoodItems();
    }
}
