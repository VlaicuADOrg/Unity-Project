using TMPro;
using UnityEngine;

public class QuestSceneUI : MonoBehaviour
{
    [SerializeField] private TMP_Text questText;

    void OnEnable()
    {
        StartCoroutine(RefreshNextFrame());
    }

    System.Collections.IEnumerator RefreshNextFrame()
    {
        yield return null;
        Refresh();
    }

    public void Refresh()
    {
        if (QuestManager.I == null)
        {
            questText.text = "QuestManager not found.";
            return;
        }

        var quests = QuestManager.I.activeQuests;

        if (quests.Count == 0)
        {
            questText.text = "No active quests.";
            return;
        }

        questText.text = "";

        foreach (var q in quests)
        {
            questText.text +=
                $"{q.text}\n\n" +
                $"Requirement: {q.itemCount}x {q.itemName}\n" +
                $"Find them: {q.findHint}\n\n"+
                $"-----------------------------------------------------------------------------------------------------------\n\n";
        }
    }
}
