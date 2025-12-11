using UnityEngine;

public class ShredderScript : MonoBehaviour
{
    private GameObject shredder;
    [SerializeField] private LayerMask pickupLayerMask;

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision);
        if(collision.gameObject.CompareTag("Shreddable"))
        {
            Debug.Log("Detected");
            Destroy(collision.gameObject);
        }
    }
}
