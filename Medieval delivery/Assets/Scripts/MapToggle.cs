using UnityEngine;

public class MapToggle : MonoBehaviour
{
    [SerializeField] private GameObject mapPanel;

    private void Start()
    {
        if (mapPanel != null)
            mapPanel.SetActive(false); 
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            if (mapPanel == null) return;

            bool show = !mapPanel.activeSelf;
            mapPanel.SetActive(show);

            Cursor.visible = show;
            Cursor.lockState = show ? CursorLockMode.None : CursorLockMode.Locked;

        }
    }

}
