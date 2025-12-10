using UnityEngine;

public class DocumentController : MonoBehaviour
{
    [SerializeField] Transform documentController;
    public int GetChildCount()
    {
        return documentController.childCount;
    }
}
