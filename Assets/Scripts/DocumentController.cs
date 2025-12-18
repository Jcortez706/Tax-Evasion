using UnityEngine;

public class DocumentController : MonoBehaviour
{
    [SerializeField] Transform documentController;
    public int GetChildCount()
    {
        int  docs = documentController.childCount;
        GameStats.Documents = docs;
        return docs;
    }
}
