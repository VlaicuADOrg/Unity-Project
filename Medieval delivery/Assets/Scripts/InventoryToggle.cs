using UnityEngine;

public class InventoryToggle : MonoBehaviour
{
    public CanvasGroup inventoryGroup;
    private bool isOpen = false;

    void Start()
    {
        HideInventory();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            ToggleInventory();
        }
    }

    void ToggleInventory()
    {
        if (isOpen) HideInventory();
        else ShowInventory();

        isOpen = !isOpen;
    }

    void ShowInventory()
    {
        inventoryGroup.alpha = 1;
        inventoryGroup.interactable = true;
        inventoryGroup.blocksRaycasts = true;
    }

    void HideInventory()
    {
        inventoryGroup.alpha = 0;
        inventoryGroup.interactable = false;
        inventoryGroup.blocksRaycasts = false;
    }

    public void CloseInventory()
    {
        HideInventory();
        isOpen = false;
    }
}
