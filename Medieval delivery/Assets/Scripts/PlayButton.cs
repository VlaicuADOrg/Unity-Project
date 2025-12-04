using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour
{
    public void LoadPlayScene()
    {
        SceneManager.LoadScene("GameScene"); 
    }
}
