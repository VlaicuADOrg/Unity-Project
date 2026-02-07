using UnityEngine;

public class MapToggle : MonoBehaviour
{
    [SerializeField] private GameObject mapPanel;

    [Header("Cursor")]
    [SerializeField] private bool keepCursorVisibleAfterClosingMap = true; 

    private bool _prevCursorVisible;
    private CursorLockMode _prevLockMode;

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

            if (show)
            {
                _prevCursorVisible = Cursor.visible;
                _prevLockMode = Cursor.lockState;

                mapPanel.SetActive(true);

                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
            }
            else
            {
                mapPanel.SetActive(false);

                if (keepCursorVisibleAfterClosingMap)
                {
                    Cursor.visible = true;
                    Cursor.lockState = CursorLockMode.None;
                }
                else
                {
                    Cursor.visible = _prevCursorVisible;
                    Cursor.lockState = _prevLockMode;
                }
            }
        }
    }
}
