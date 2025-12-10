using UnityEngine;
using TMPro;

public class SetObjectiveText : MonoBehaviour
{
    [SerializeField] private GameObject documentOwner;
    [SerializeField] private TMP_Text textObjext;
    DocumentController documentController;
    float totalDocuments = 10;

    private void Start()
    {
        documentController =  documentOwner.GetComponent<DocumentController>();
        textObjext.SetText(totalDocuments + " Documents Left");
    }

    // Update is called once per frame
    void Update()
    {
        if(documentController != null)
        {
            totalDocuments = documentController.GetChildCount();
            textObjext.SetText(totalDocuments + " Documents Left");
        }



    }
}
