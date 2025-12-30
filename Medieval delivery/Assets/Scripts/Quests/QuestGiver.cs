using System.Collections.Generic;
using UnityEngine;

public class QuestGiver : MonoBehaviour
{
    [Header("Identity")]
    public string giverKey;      // ex: "Coin", "StarCoin", ...
    public string displayName;   // if empty, uses giverKey

    [Header("Quest pool")]
    public bool loadFromCatalog = true;

    [Tooltip("How many quests (random) this NPC will have available at start.")]
    public int minQuests = 1;
    public int maxQuests = 8;

    public List<Quest> quests = new();

    private Quest _activeQuest;

    private void Start()
    {
        if (string.IsNullOrWhiteSpace(displayName)) displayName = giverKey;

        if (loadFromCatalog)
        {
            var pool = QuestCatalog.BuildPool(giverKey);
            quests = QuestCatalog.PickRandomSubset(pool, minQuests, maxQuests);
        }
    }

    public void OnLeftClick()
    {
        if (QuestPopupUI.I == null) return;
        if (PlayerInventory.I == null)
        {
            QuestPopupUI.I.Show("PlayerInventory not found in the scene.");
            return;
        }

        // If already has an active quest: either turn-in (if player has items) or "finish first"
        if (_activeQuest != null && _activeQuest.isActive && !_activeQuest.isCompleted)
        {
            if (PlayerInventory.I.Has(_activeQuest.itemTag, _activeQuest.itemCount))
            {
                PlayerInventory.I.Remove(_activeQuest.itemTag, _activeQuest.itemCount);
                _activeQuest.isCompleted = true;
                _activeQuest.isActive = false;

                QuestPopupUI.I.Show(QuestCatalog.BuildTurnInText(giverKey, displayName, _activeQuest));
                _activeQuest = null;
            }
            else
            {
                QuestPopupUI.I.Show(QuestCatalog.BuildBusyText(giverKey, displayName, _activeQuest));
            }
            return;
        }

        // Pick a new quest
        var available = new List<Quest>();
        foreach (var q in quests)
            if (!q.isCompleted && !q.isActive)
                available.Add(q);

        if (available.Count == 0)
        {
            QuestPopupUI.I.Show(QuestCatalog.BuildNoQuestText(giverKey, displayName));
            return;
        }

        var picked = available[Random.Range(0, available.Count)];
        picked.isActive = true;
        picked.isCompleted = false;
        _activeQuest = picked;

        QuestPopupUI.I.Show(QuestCatalog.BuildGiveQuestText(giverKey, displayName, picked));
    }
}
