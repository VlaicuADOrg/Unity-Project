using UnityEngine;
using UnityEngine.SceneManagement;

public class InventorySceneLoader : MonoBehaviour
{
    private bool isOpen = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (isOpen)
                CloseInventory();
            else
                OpenInventory();
        }
    }

    void OpenInventory()
    {
        SceneManager.LoadScene("InventoryScene", LoadSceneMode.Additive);
        isOpen = true;
    }

    void CloseInventory()
    {
        SceneManager.UnloadSceneAsync("InventoryScene");
        isOpen = false;
    }
}
