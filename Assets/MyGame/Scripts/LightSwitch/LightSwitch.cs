using UnityEngine;

public class LightSwitch : MonoBehaviour, IInteractable
{
 
    public GameObject lightObject;
    private bool isOn = true;

    public void Interact()
    {
        isOn = !isOn;
        lightObject.SetActive(isOn);
    }
}
