using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chair : MonoBehaviour
{
    public GameObject player, intText, standText;
    public Transform seatPoint, standPoint;
    public bool interactable, sitting;

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject == player )
        {
            intText.SetActive(true);
            interactable = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player )
        {
            intText.SetActive(false);
            interactable = false;
        }
    }
    void Update()
    {
        if (interactable == true)
        {
            if (Input.GetKeyDown(KeyCode.B))
            {
                intText.SetActive(false);
                standText.SetActive(true);
                player.transform.position = seatPoint.position;
                player.transform.rotation = seatPoint.rotation;
                sitting = true;
                interactable = false;
            }
        }
        if (sitting == true)
        {
            if (Input.GetKeyDown(KeyCode.N))
            {
                player.transform.position = standPoint.position;
                player.transform.rotation = standPoint.rotation;
                standText.SetActive(false);
                sitting = false;
            }
        }
    }
}
