using UnityEngine;

public class LightSwitch : MonoBehaviour, IInteractable
{
    public GameObject light;
    public bool isTurnOn = true;

    public void Interact()
    {
        isTurnOn = !isTurnOn;
        if (isTurnOn)
        {
            light.SetActive(true);
        }
        else
        {
            light.SetActive(false);
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
