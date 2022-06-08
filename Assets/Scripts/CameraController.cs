using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [HideInInspector] private Transform player;
    [HideInInspector] private float rotationX = 0f;
    [HideInInspector] private float zoomVelocity;

    [Header("General")]
    [SerializeField] private float mouseSensitivity = 200f;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        HandleRotation();
    }

    private void HandleRotation()
    {
        if (Cursor.lockState == CursorLockMode.Confined)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }

        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        rotationX = Mathf.Clamp(rotationX - mouseY, -70f, 70f);
        transform.localRotation = Quaternion.Euler(rotationX, 0f, 0f);

        player.Rotate(Vector3.up, mouseX);
    }
}
