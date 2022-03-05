using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    public float lookSensitivity = 100f;
    [SerializeField] public Transform playerTransform;
    [SerializeField] public Transform cameraTransform;
    float xRotation = 0f;
    Vector2 lookInput;

    public void ReceiveLookInput(Vector2 _lookInput) {
        lookInput = _lookInput;
    }

    void Start()
    {
        // keeps mouse within the boundaries of the screen
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // calculate rotation about the x-axis using mouse y
        xRotation -= lookInput.y * lookSensitivity * Time.deltaTime;

        // clamp vertical rotation
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        
        // apply rotation about the x-axis (look up/down)
        cameraTransform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        // apply rotation
        playerTransform.Rotate(Vector3.up * lookInput.x * lookSensitivity * Time.deltaTime);
    }
}
