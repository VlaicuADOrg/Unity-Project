using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public string itemTag;
    public string itemName;
    public int amount = 1;

    [Header("UI prompt optional")]
    public GameObject pressEPrompt;

    private bool _playerInside;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        _playerInside = true;
        if (pressEPrompt) pressEPrompt.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        _playerInside = false;
        if (pressEPrompt) pressEPrompt.SetActive(false);
    }

    private void Update()
    {
        if (!_playerInside) return;

        if (Input.GetKeyDown(KeyCode.E))
        {
            PlayerInventory.I.Add(itemTag, amount);
            if (pressEPrompt) pressEPrompt.SetActive(false);
            gameObject.SetActive(false); // hide (cum ai cerut)
        }
    }
}
