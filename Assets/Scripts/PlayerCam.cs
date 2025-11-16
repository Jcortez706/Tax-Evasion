using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCam : MonoBehaviour
{
    InputAction moveCamera;

    public float MIN_CAMERA_ANGLE;
    public float MAX_CAMERA_ANGLE;

    public float sensitivity;

    public Transform orientation;

    float xRotation;
    float yRotation;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        moveCamera = InputSystem.actions.FindAction("Look");

    }


    private void Update()
    {
        Vector2 lookValue = moveCamera.ReadValue<Vector2>() * Time.deltaTime * sensitivity;

        yRotation += lookValue.x;
        xRotation -= lookValue.y;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        // rotate cam and orientation
        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        orientation.rotation = Quaternion.Euler(0, yRotation, 0);

    }
}
