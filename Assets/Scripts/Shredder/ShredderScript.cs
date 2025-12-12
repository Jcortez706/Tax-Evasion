using UnityEngine;

public class ShredderScript : MonoBehaviour
{
    private GameObject shredder;
    [SerializeField] private LayerMask pickupLayerMask;
    private bool isHolding = false;

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision);
        if(collision.gameObject.CompareTag("Shreddable"))
        {
            isHolding = true;
            
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if(collision.gameObject.CompareTag("Shreddable"))
        {
            isHolding = false;

        }
    }

    public void destroyHeldObject(GameObject document)
    {
        if (document.CompareTag("Shreddable"))
        {
            Destroy(document);
        }
        else
        {
            Debug.Log("Object not shreddable " + document);
        }
    }
}
