using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    public Transform CameraTransform;

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

        _currentCameraRotation.x -= cameraRotY;
        _currentCameraRotation.y += cameraRotX;

        _currentCameraRotation.x = Mathf.Clamp(_currentCameraRotation.x, -90f, 90f);

        CameraTransform.localEulerAngles = _currentCameraRotation;
    }
}