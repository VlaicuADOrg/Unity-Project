using UnityEngine;
// Dacă folosești TMP:
using TMPro;

public class QuestPopupUI : MonoBehaviour
{
    public static QuestPopupUI I { get; private set; }

    [SerializeField] private GameObject root;
    [SerializeField] private TMP_Text messageText; // dacă nu ai TMP, schimbă cu UnityEngine.UI.Text

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

        // ca să nu se închidă din același click
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

        // orice click / orice tastă
        if (Input.anyKeyDown || Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
        {
            HideImmediate();
        }
    }
}
