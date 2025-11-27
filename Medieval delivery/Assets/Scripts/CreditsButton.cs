using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsButton : MonoBehaviour
{
    public void LoadCreditsScene()
    {
        SceneManager.LoadScene("Credits"); 
    }
}
