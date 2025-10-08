using UnityEngine;

public class Chair : MonoBehaviour, IInteractable
{
    public Transform seatPoint, standPoint;
    public GameObject player;
    public float sitYOffset = 0.35f;

    bool sitting;
    Collider playerCol;
    Collider chairCol;

    void Start()
    {
        playerCol = player.GetComponentInChildren<Collider>();
        chairCol = GetComponent<Collider>();
    }

    public void Interact()
    {
        if (!sitting)
        {
            Physics.IgnoreCollision(playerCol, chairCol, true);

            player.transform.position = seatPoint.position - new Vector3(0, sitYOffset, 0);
            Vector3 euler = seatPoint.rotation.eulerAngles;
            player.transform.rotation = Quaternion.Euler(0, euler.y, 0);

            sitting = true;
        }
        else
        {
            Physics.IgnoreCollision(playerCol, chairCol, false);
            player.transform.position = standPoint.position;

            sitting = false;
        }
    }
}

