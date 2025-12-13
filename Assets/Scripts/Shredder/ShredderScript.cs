using UnityEngine;

public class ShredderScript : MonoBehaviour
{ 
    [SerializeField] public string shreddableObjectTag;
    [SerializeField] private GameObject documentHolder;
    private GameObject objectHeld;

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision);
        if(collision.gameObject.CompareTag(shreddableObjectTag) && collision.gameObject != objectHeld)
        {
            // Get GameObject and Rigidbody
            GameObject tempHolder = collision.gameObject;
            Rigidbody tempRigidBody = tempHolder.GetComponent<Rigidbody>();


            // Freeze object in place
            tempRigidBody.useGravity = false;
            tempRigidBody.angularVelocity = new Vector3(0, 0, 0);
            tempRigidBody.linearVelocity = new Vector3(0, 0, 0);
            tempRigidBody.constraints = RigidbodyConstraints.FreezeAll;

            // Move the gameobject into shredder
            tempHolder.transform.position = documentHolder.transform.position;
            tempHolder.transform.rotation = documentHolder.transform.rotation;

            // Set the object to objectHeld
            objectHeld = collision.gameObject;
            
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if(collision.gameObject.CompareTag(shreddableObjectTag))
        {
            Rigidbody tempRigidBody = collision.gameObject.GetComponent<Rigidbody>();
            tempRigidBody.useGravity = true;

            tempRigidBody.constraints = RigidbodyConstraints.None;


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
