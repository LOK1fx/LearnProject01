using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    public Transform CameraTransform;
    public float Sensitivity = 9f;
    public float MinViewAngle = -90f;
    public float MaxViewAngle = -90f;

    private Vector3 _currentCameraRotation;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        float cameraRotX = Input.GetAxis("Mouse X");
        float cameraRotY = Input.GetAxis("Mouse Y");

        _currentCameraRotation.x -= cameraRotY * Time.deltaTime * Sensitivity;
        _currentCameraRotation.y += cameraRotX * Time.deltaTime * Sensitivity;

        _currentCameraRotation.x = Mathf.Clamp(_currentCameraRotation.x, -90f, 90f);

        CameraTransform.localEulerAngles = new Vector3(_currentCameraRotation.x, 0f, 0f);
        transform.localEulerAngles = new Vector3(0f, _currentCameraRotation.y, 0f);
    }
}