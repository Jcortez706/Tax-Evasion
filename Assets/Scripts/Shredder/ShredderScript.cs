using UnityEngine;

public class ShredderScript : MonoBehaviour
{ 
    [SerializeField] public string shreddableObjectTag;
    private bool isHolding = false;

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision);
        if(collision.gameObject.CompareTag(shreddableObjectTag))
        {
            isHolding = true;
            
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if(collision.gameObject.CompareTag(shreddableObjectTag))
        {
            isHolding = false;

        }
    }

    public void destroyHeldObject(GameObject document)
    {
        if (document.CompareTag(shreddableObjectTag))
        {
            Destroy(document);
        }
        else
        {
            Debug.Log("Object not shreddable " + document);
        }
    }
}
