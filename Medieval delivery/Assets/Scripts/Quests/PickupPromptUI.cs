using UnityEngine;
using TMPro;

public class PickupPromptUI : MonoBehaviour
{
    public static PickupPromptUI I { get; private set; }

    [SerializeField] private GameObject root;   
    [SerializeField] private TMP_Text label;    

    private void Awake()
    {
        I = this;
        Hide();
    }

    public void Show(string itemName)
    {
        if (root) root.SetActive(true);
        if (label) label.text = $"{itemName}\nPress E to take";
    }

    public void Hide()
    {
        if (root) root.SetActive(false);
    }
}
