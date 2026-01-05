using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlsSceneLoader : MonoBehaviour
{
    private bool isOpen = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            if (isOpen)
                CloseControlsScene();
            else
                OpenControlsScene();
        }
    }

    void OpenControlsScene()
    {
        SceneManager.LoadScene("ControlsScene", LoadSceneMode.Additive);
        isOpen = true;
    }

    void CloseControlsScene()
    {
        SceneManager.UnloadSceneAsync("ControlsScene");
        isOpen = false;
    }
}
