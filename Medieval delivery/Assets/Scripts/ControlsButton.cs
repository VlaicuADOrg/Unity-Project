using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlsButton : MonoBehaviour
{
    public void LoadControlsScene()
    {
        SceneManager.LoadScene("ControlsScene");
    }
}
