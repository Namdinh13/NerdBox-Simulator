using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class FoodPickup : MonoBehaviour
{
    public GameObject player;
    // tham chiếu gói bim bim

    public List<GameObject> bimbims = new List<GameObject>();

    public GameObject foodOb;

    public GameObject foodNearUI;

    private bool nearShelf = false; 
    private bool hasFood = false;


    private void Start()
    {
        foodNearUI.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C) && nearShelf && !hasFood && bimbims.Count > 0)
        {
            // Sinh ra gói bim bim
            foodOb = bimbims[bimbims.Count - 1];

            bimbims.Remove(foodOb);

            foodOb.transform.SetParent(Camera.main.transform);

            // Đặt vị trí bim bim vào tay
            foodOb.transform.localPosition = new Vector3(-0.4f, -0.3f, 0.75f);
            hasFood = true;
        }
        
        if (Input.GetKeyDown(KeyCode.V) && hasFood)
        {
            // Phá gói bim bim
            Destroy(foodOb);
            hasFood = false;
        }
    }

 
    private void OnTriggerEnter(Collider other)
    {
        Player hoomen = other.GetComponentInParent<Player>();
        if(hoomen != null)
        {
            // Nếu là player tiến gần
            nearShelf = true;
            foodNearUI.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        Player hoomen = other.GetComponentInParent<Player>();
        if (hoomen != null)
        {
            // Nếu là player đi xa
            nearShelf = false;
            foodNearUI.SetActive(false);
        }
    }
}
