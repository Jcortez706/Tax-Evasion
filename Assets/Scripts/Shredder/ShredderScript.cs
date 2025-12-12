using UnityEngine;

public class ShredderScript : MonoBehaviour
{ 
    [SerializeField] public string shreddableObjectTag;
    private GameObject objectHeld;

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision);
        if(collision.gameObject.CompareTag(shreddableObjectTag))
        {
            objectHeld = collision.gameObject;
            
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if(collision.gameObject.CompareTag(shreddableObjectTag))
        {
            objectHeld = null;

        }
    }

    public void destroyHeldObject(GameObject document)
    {
        if (document.CompareTag(shreddableObjectTag) && document == objectHeld)
        {
            Destroy(document);
        }
        else
        {
            Debug.Log("Object not shreddable " + document);
        }
    }
}
