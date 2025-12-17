using UnityEngine;

public class CursorState : MonoBehaviour
{
   
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }


}
