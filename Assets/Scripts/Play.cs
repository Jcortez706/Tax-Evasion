using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Play : MonoBehaviour
{

    public void OnButtonClick()
    {
        SceneManager.LoadScene("dev");
    }

    
}
