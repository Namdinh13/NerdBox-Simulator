using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chair : MonoBehaviour
{
    public GameObject Player, intText, standText;
    public Transform seatPoint, standPoint;
    public bool interactable, sitting;

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject == Player)
        {
            intText.SetActive(true);
            interactable = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == Player)
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
                Player.transform.localPosition = seatPoint.position;
                sitting = true;
                interactable = true;
            }
        }
        if (sitting == true)
        {
            if (Input.GetKeyDown(KeyCode.N))
            {
                Player.transform.localPosition = standPoint.position;
                standText.SetActive(false);
                sitting = false;
            }
        }
    }
}
