using UnityEngine;
using UnityEngine.SceneManagement;

public class QuestSceneLoader : MonoBehaviour
{
    private bool isOpen = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (isOpen)
                CloseInventory();
            else
                OpenInventory();
        }
    }

    void OpenInventory()
    {
        SceneManager.LoadScene("Quests", LoadSceneMode.Additive);
        isOpen = true;
    }

    void CloseInventory()
    {
        SceneManager.UnloadSceneAsync("Quests");
        isOpen = false;
    }
}
