using UnityEngine;
using TMPro;
using System.Text;

public class InventoryUI : MonoBehaviour
{
    public TMP_Text inventoryText;

    void OnEnable()
    {
        Refresh();
    }

    public void Refresh()
    {
        if (PlayerInventory.I == null)
        {
            inventoryText.text = "Inventory indisponibil";
            return;
        }

        var items = PlayerInventory.I.Items;

        if (items.Count == 0)
        {
            inventoryText.text = "Inventory gol";
            return;
        }

        StringBuilder sb = new StringBuilder();

        foreach (var item in items)
        {
            sb.AppendLine($"{item.Key} x{item.Value}");
        }

        inventoryText.text = sb.ToString();
    }
}
