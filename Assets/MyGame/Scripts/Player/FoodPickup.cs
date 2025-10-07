using System.Collections.Generic;
using UnityEngine;

public class FoodPickup : MonoBehaviour, IInteractable
{
    public List<GameObject> bimbims = new List<GameObject>();
    public GameObject foodInHand;
    private bool hasFood = false;

    public void Interact()
    {
        if (!hasFood && bimbims.Count > 0)
        {
            foodInHand = bimbims[bimbims.Count - 1];
            bimbims.RemoveAt(bimbims.Count - 1);
            foodInHand.transform.SetParent(Camera.main.transform);
            foodInHand.transform.localPosition = new Vector3(-0.4f, -0.3f, 0.75f);
            hasFood = true;
        }
        else if (hasFood)
        {
            Destroy(foodInHand);
            hasFood = false;
        }
    }
}