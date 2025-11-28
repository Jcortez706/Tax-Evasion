using UnityEngine;
using UnityEngine.InputSystem;

public class GrabMechanic : MonoBehaviour
{
    [Header("Settings")]
    public Transform cameraTransform; // Assign your Main Camera here
    public float distance = 3.0f;     // How far away the object hovers
    InputAction interactWithObject;

    void LateUpdate()
    {
        if (cameraTransform == null) return;

        transform.position = cameraTransform.position + (cameraTransform.forward * distance);

        transform.rotation = cameraTransform.rotation;

        


    }
}
