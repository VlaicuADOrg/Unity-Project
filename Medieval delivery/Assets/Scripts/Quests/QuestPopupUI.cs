using UnityEngine;
// Dacă folosești TMP:
using TMPro;

public class QuestPopupUI : MonoBehaviour
{
    public static QuestPopupUI I { get; private set; }

    [SerializeField] private GameObject root;
    [SerializeField] private TMP_Text messageText; 

    private float _canCloseAfter;

    private void Awake()
    {
        I = this;
        HideImmediate();
    }

    public bool IsOpen => root != null && root.activeSelf;

    public void Show(string msg)
    {
        if (!root || !messageText) return;

        messageText.text = msg;
        root.SetActive(true);


        _canCloseAfter = Time.unscaledTime + 0.15f;
    }

    public void HideImmediate()
    {
        if (root) root.SetActive(false);
    }

    private void Update()
    {
        if (!IsOpen) return;
        if (Time.unscaledTime < _canCloseAfter) return;

        if (Input.anyKeyDown || Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
        {
            HideImmediate();
        }
    }
}
