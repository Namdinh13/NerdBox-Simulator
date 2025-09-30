using UnityEngine;
using UnityEngine.UI;

public class FoodPickup : MonoBehaviour
{
    public GameObject player, pickText, eatText;     
    public AudioSource audioSrc;  
    public AudioClip eatSound;
    public Image foodImage;
    private bool nearShelf = false; 
    private bool hasFood = false;   

    void Update()
    {
      
        if (nearShelf && !hasFood && Input.GetKeyDown(KeyCode.C))
        {
            hasFood = true;
            foodImage.gameObject.SetActive(true);
            pickText.SetActive(false);
            eatText.SetActive(true);
        }

      
        if (hasFood && Input.GetKeyDown(KeyCode.V))
        {
            hasFood = false;
            foodImage.gameObject.SetActive(false);
            pickText.SetActive(false);
            eatText.SetActive(true);
            if (audioSrc != null && eatSound != null)
            {
                audioSrc.PlayOneShot(eatSound);
            }
        }
    }

 
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("snack shelf"))
            pickText.SetActive(true);
            nearShelf = true;
    }

   
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("snack shelf"))
            pickText.SetActive(false);
            nearShelf = false;
    }
}
