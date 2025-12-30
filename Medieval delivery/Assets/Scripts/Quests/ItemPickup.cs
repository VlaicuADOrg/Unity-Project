using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public string itemTag;
    public string itemName;
    public int amount = 1;

    private bool _playerInside;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        _playerInside = true;

        if (PickupPromptUI.I != null)
        {
            string showName = string.IsNullOrWhiteSpace(itemName) ? gameObject.name : itemName;
            PickupPromptUI.I.Show(showName);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        _playerInside = false;

        if (PickupPromptUI.I != null)
            PickupPromptUI.I.Hide();
    }

    private void Update()
    {
        if (!_playerInside) return;

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (PlayerInventory.I != null)
                PlayerInventory.I.Add(itemTag, amount);

            if (PickupPromptUI.I != null)
                PickupPromptUI.I.Hide();

            gameObject.SetActive(false); // hide item
        }
    }
}
