using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public static PlayerInventory I { get; private set; }

    // key = itemTag, value = count
    private readonly Dictionary<string, int> _counts = new();

    private void Awake()
    {
        if (I != null && I != this) { Destroy(gameObject); return; }
        I = this;
        // Optional: DontDestroyOnLoad(gameObject);
    }

    public int CountOf(string itemTag)
    {
        if (string.IsNullOrWhiteSpace(itemTag)) return 0;
        return _counts.TryGetValue(itemTag, out var c) ? c : 0;
    }

    public bool Has(string itemTag, int amount)
        => CountOf(itemTag) >= amount;

    public void Add(string itemTag, int amount)
    {
        if (string.IsNullOrWhiteSpace(itemTag) || amount <= 0) return;

        _counts.TryGetValue(itemTag, out var current);
        _counts[itemTag] = current + amount;
    }

    public bool Remove(string itemTag, int amount)
    {
        if (!Has(itemTag, amount)) return false;

        _counts[itemTag] -= amount;
        if (_counts[itemTag] <= 0) _counts.Remove(itemTag);
        return true;
    }
}
