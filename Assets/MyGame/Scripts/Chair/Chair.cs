using UnityEngine;

public class Chair : MonoBehaviour, IInteractable
{
    public Transform seatPoint, standPoint;
    public GameObject standText;
    private bool sitting = false;
    private GameObject Player;

    private void Start()
    {
        if (standText != null)
            standText.SetActive(false);
    }

    public void Interact()
    {
        if (!sitting)
        {
            SitDown();
        }
        else
        {
            StandUp();
        }
    }
    private void SitDown()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        if (Player != null)
        {
            Player.transform.position = seatPoint.position;
            sitting = true;
            if (standText != null)
                standText.SetActive(true);
        }
    }
    private void StandUp()
    {
        if (Player != null)
        {
            Player.transform.position = standPoint.position;
            sitting = false;
            if (standText != null)
                standText.SetActive(false);
        }
    }
}
