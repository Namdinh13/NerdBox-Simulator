using System;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private Transform cameraTransform;
    [SerializeField] private float mouseSensitivity = 2f;
    [SerializeField] private float lookRange = 80f;
    [SerializeField] private Vector3 cameraOriginPosition;

    [SerializeField] private GameObject interactUI;
    private IInteractable currentTarget;


    private float verticalRotation = 0f;
    private Rigidbody rb;


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
        cameraOriginPosition = cameraTransform.localPosition;

        if (interactUI != null ) interactUI.SetActive(false );

    }

    private void FixedUpdate()
    {
        HandleMovement();
        HandleCamera();
        HandleInteract();
        
    }

    private void HandleMovement()
    {
        Vector2 inputVector = GameInput.Instance.GetMovementVectorNormalized();

        Vector3 inputDir = new Vector3(inputVector.x, 0f, inputVector.y);
        Vector3 cameraForward = cameraTransform.forward;
        Vector3 cameraRight = cameraTransform.right;

        cameraForward.y = 0f;
        cameraRight.y = 0f;
        cameraForward.Normalize();
        cameraRight.Normalize();

        Vector3 moveDir = (cameraForward * inputDir.z + cameraRight * inputDir.x).normalized * moveSpeed;
        moveDir.y = rb.linearVelocity.y;

        rb.linearVelocity = moveDir;
        cameraTransform.localPosition = cameraOriginPosition;
    }

    private void HandleCamera()
    {
        Vector2 lookInput = GameInput.Instance.GetLookVectorNormalized();

        // Xoay body theo chiều ngang
        transform.Rotate(0, lookInput.x * mouseSensitivity, 0);

        // Xoay cam theo chiều dọc
        verticalRotation -= lookInput.y;
        verticalRotation = Mathf.Clamp(verticalRotation, -lookRange, lookRange);
        cameraTransform.localRotation = Quaternion.Euler(verticalRotation * mouseSensitivity, cameraTransform.localEulerAngles.y, 0);
    }

    private void HandleInteract()
    {
        Ray ray = new Ray(cameraTransform.position, cameraTransform.forward);
        if (Physics.Raycast(ray, out RaycastHit hit, 3f))
        {
            currentTarget = hit.transform.GetComponent<IInteractable>();
            if (currentTarget != null)
            {
                if (interactUI != null) interactUI.SetActive(true);
                if (Input.GetKeyDown(KeyCode.E))
                    currentTarget.Interact();
                return;
            }
        }
        currentTarget = null;
        if (interactUI != null) interactUI.SetActive(false);
    }

}
