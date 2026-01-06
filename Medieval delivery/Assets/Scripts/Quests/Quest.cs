using System;
using UnityEngine;

[Serializable]
public class Quest
{
    [TextArea(2, 6)]
    public string text;

    
    [TextArea(1, 4)]
    public string findHint;

    public string itemTag;
    public string itemName;
    public int itemCount = 1;

    public bool isActive;
    public bool isCompleted;
}
