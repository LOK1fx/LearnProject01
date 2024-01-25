using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    public Transform CameraTransform => _cameraTransform;

    [SerializeField] private Transform _cameraTransform;

    [SerializeField] private float _sensitivity = 9f;
    [SerializeField] private float _minViewAngle = -90f;
    [SerializeField] private float _maxViewAngle = -90f;

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

        _currentCameraRotation.x -= cameraRotY * Time.deltaTime * _sensitivity;
        _currentCameraRotation.y += cameraRotX * Time.deltaTime * _sensitivity;

        _currentCameraRotation.x = Mathf.Clamp(_currentCameraRotation.x, _minViewAngle, _maxViewAngle);

        CameraTransform.localEulerAngles = new Vector3(_currentCameraRotation.x, 0f, 0f);
        transform.localEulerAngles = new Vector3(0f, _currentCameraRotation.y, 0f);
    }
}