using System;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] private float moveSpeed = 7f;
    //[SerializeField] private float rotateSpeed = 1f;


    [SerializeField] private Transform cameraTransform;
    [SerializeField] private float mouseSensitivity = 2f;
    [SerializeField] private float lookRange = 80f;
    [SerializeField] private Vector3 cameraOriginPosition;
    private float verticalRotation = 0f;
    private Rigidbody rb;


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
        cameraOriginPosition = cameraTransform.localPosition;
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

        // Di chuyển
        //transform.position += moveDir * moveSpeed;
        //rb.AddForce(moveDir * moveSpeed);
        rb.linearVelocity = moveDir;
        cameraTransform.localPosition = cameraOriginPosition;
        //transform.forward = Vector3.Slerp(transform.forward, moveDir, Time.deltaTime * rotateSpeed);
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
        Vector3 screenCenter = new Vector3(Screen.width * 0.5f, Screen.height * 0.5f, 0f);
        Ray ray = Camera.main.ScreenPointToRay(screenCenter);

        Debug.DrawRay(ray.origin, ray.direction * 5f, Color.red);

        if (Physics.Raycast(ray, out RaycastHit hit, 5f) && hit.transform.GetComponent<IInteractable>() != null)
        {
            if (Input.GetKeyDown(KeyCode.T))
            {
                hit.transform.GetComponent<IInteractable>().Interact();
            }
        }
    }

}
