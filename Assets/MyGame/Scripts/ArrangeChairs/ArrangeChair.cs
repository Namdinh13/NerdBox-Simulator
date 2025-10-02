using System.Diagnostics;
using UnityEngine;

public class ArrangeChair : MonoBehaviour
{
    public GameObject chair;
    public Vector3 newPosition;
    public Vector3 newRotation;

    private void OnMouseDown()
    {
        if (chair != null)
        {
            chair.transform.position = newPosition;
            chair.transform.rotation = Quaternion.Euler(newRotation);
           
        }
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
