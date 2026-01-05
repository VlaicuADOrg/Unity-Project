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
                CloseQuestScene();
            else
                OpenQuestScene();
        }
    }

    void OpenQuestScene()
    {
        SceneManager.LoadScene("Quests", LoadSceneMode.Additive);
        isOpen = true;
    }

    void CloseQuestScene()
    {
        SceneManager.UnloadSceneAsync("Quests");
        isOpen = false;
    }
}
