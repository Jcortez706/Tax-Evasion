using UnityEngine;
using UnityEngine.InputSystem;

public class GrabMechanic : MonoBehaviour
{
    [Header("Settings")]
    public Transform cameraTransform;
    public float distance = 3.0f;


    void LateUpdate()
    {
        if (cameraTransform == null) return;

        transform.position = cameraTransform.position + (cameraTransform.forward * distance);

        transform.rotation = cameraTransform.rotation;
    }
}