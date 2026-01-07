using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ScrollRemember : MonoBehaviour
{
    [SerializeField] private ScrollRect scrollRect;

    [Header("Save")]
    [Tooltip("Cheie unica (ex: QuestsScroll). Daca ai mai multe scroll-uri, schimba cheia.")]
    [SerializeField] private string saveKey = "QuestsScroll";
    [Tooltip("Daca e ON, tine minte si dupa restart la joc (PlayerPrefs). Daca e OFF, doar cat ruleaza jocul.")]
    [SerializeField] private bool persistBetweenRuns = false;

    private static readonly System.Collections.Generic.Dictionary<string, float> _runtime =
        new System.Collections.Generic.Dictionary<string, float>();

    private void Reset()
    {
        scrollRect = GetComponent<ScrollRect>();
    }

    private void Awake()
    {
        if (scrollRect == null) scrollRect = GetComponent<ScrollRect>();

        if (scrollRect != null)
            scrollRect.onValueChanged.AddListener(_ => Save());
    }

    private void OnEnable()
    {
        StartCoroutine(RestoreNextFrame());
    }

    private void OnDisable()
    {
        Save();
    }

    private void Save()
    {
        if (scrollRect == null) return;

        float v = scrollRect.verticalNormalizedPosition;

        if (persistBetweenRuns)
        {
            PlayerPrefs.SetFloat(saveKey, v);
            PlayerPrefs.Save();
        }
        else
        {
            _runtime[saveKey] = v;
        }
    }

    private IEnumerator RestoreNextFrame()
    {
       
        yield return null;
        Canvas.ForceUpdateCanvases();

        if (scrollRect == null) yield break;

        float v = 1f; 
        if (persistBetweenRuns)
        {
            if (PlayerPrefs.HasKey(saveKey)) v = PlayerPrefs.GetFloat(saveKey, 1f);
        }
        else
        {
            if (_runtime.TryGetValue(saveKey, out var saved)) v = saved;
        }

        scrollRect.verticalNormalizedPosition = v;
        scrollRect.StopMovement();
    }
}
