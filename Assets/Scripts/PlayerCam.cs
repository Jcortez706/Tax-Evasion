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
        if (!orientation)
        {
            Debug.LogError("Orientation not set");
        }
        if (Mathf.Abs(sensitivity) < 1e-5f)
        {
            Debug.LogError("Sensitivity not set or 0");
        }
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        moveCamera = InputSystem.actions.FindAction("Look");

    }


    private void LateUpdate()
    {
        Vector2 lookValue = moveCamera.ReadValue<Vector2>() * Time.deltaTime * sensitivity;

        yRotation += lookValue.x;
        xRotation -= lookValue.y;
        xRotation = Mathf.Clamp(xRotation, MIN_CAMERA_ANGLE, MAX_CAMERA_ANGLE);

        // rotate cam and orientation
        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        orientation.rotation = Quaternion.Euler(0, yRotation, 0);

    }
}
