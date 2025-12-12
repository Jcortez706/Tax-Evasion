using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerPickUpDrop : MonoBehaviour
{

    PlayerControls playerControls;
    [SerializeField] private Transform cameraTransform;
    [SerializeField] private LayerMask pickupLayerMask;
    [SerializeField] private LayerMask shreddableLayerMask;
    [SerializeField] private Transform objectGrabPointTransform;
    public float distance = 3.0f;

    private ObjectGrabbable objectGrabbable;
    [SerializeField] private GameObject shredder;
    private GameObject objectToDelete;



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


                    objectToDelete = raycastHit.transform.gameObject;
                    Debug.Log(objectToDelete);
                    this.objectGrabbable = objectGrabbable;
                    objectGrabbable.Grab(objectGrabPointTransform);
                    Debug.Log(objectGrabbable);
                } else if (
                    raycastHit.transform.TryGetComponent(out ShredderScript shredder)
                    )
                {
                    Debug.Log(objectToDelete);
                    if (objectToDelete)
                    {
                        shredder.destroyHeldObject(objectToDelete);
                    }
                }
            }
        }else
        {
            objectGrabbable.Drop();
            objectGrabbable = null;
        }

    }
}
