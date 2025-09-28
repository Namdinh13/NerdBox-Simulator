using UnityEngine;
using UnityEngine.UI;

public class FoodPickup : MonoBehaviour
{
    public GameObject foodUI;     
    public AudioSource audioSrc;  
    public AudioClip eatSound;    

    private bool nearShelf = false; 
    private bool hasFood = false;   

    void Update()
    {
      
        if (nearShelf && !hasFood && Input.GetKeyDown(KeyCode.E))
        {
            hasFood = true;
            foodUI.SetActive(true); 
        }

      
        if (hasFood && Input.GetKeyDown(KeyCode.Q))
        {
            hasFood = false;
            foodUI.SetActive(false); 
            if (audioSrc != null && eatSound != null)
            {
                audioSrc.PlayOneShot(eatSound);
            }
        }
    }

 
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("SnackShelf"))
        {
            nearShelf = true;
        }
    }

   
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("FoodShelf"))
        {
            nearShelf = false;
        }
    }
}
