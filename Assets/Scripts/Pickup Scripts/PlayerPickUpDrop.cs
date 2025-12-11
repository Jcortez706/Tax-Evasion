using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerPickUpDrop : MonoBehaviour
{

    PlayerControls playerControls;
    [SerializeField] private Transform cameraTransform;
    [SerializeField] private LayerMask pickupLayerMask;
    [SerializeField] private Transform objectGrabPointTransform;
    public float distance = 3.0f;

    private ObjectGrabbable objectGrabbable;



    private void Awake()
    {
        playerControls = new PlayerControls();

    }

    private void OnEnable()
    {
        playerControls.Enable();
        playerControls.Player.Interact.performed += Interact;
    }

    private void OnDisable()
    {
        playerControls.Player.Interact.performed -= Interact;
        playerControls.Disable();
    }

    private void Interact(InputAction.CallbackContext context)
    {
        if (objectGrabbable == null)
        {
            // Create a RayCast
            if (Physics.Raycast(
                cameraTransform.position,
                cameraTransform.forward,
                out RaycastHit raycastHit,
                distance,
                pickupLayerMask
                )
            )
            {
                if (raycastHit.transform.TryGetComponent(out ObjectGrabbable objectGrabbable))
                {
                    this.objectGrabbable = objectGrabbable;
                    objectGrabbable.Grab(objectGrabPointTransform);
                    Debug.Log(objectGrabbable);
                }
            }
        }else
        {
            objectGrabbable.Drop();
            objectGrabbable = null;
        }

    }
}
