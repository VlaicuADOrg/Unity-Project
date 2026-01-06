using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuBackOnEsc : MonoBehaviour
{
    [SerializeField] private string mainMenuSceneName = "MainMenu";

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (SceneManager.GetActiveScene().name == mainMenuSceneName) return;

            SceneManager.LoadScene(mainMenuSceneName);
        }
    }
}
