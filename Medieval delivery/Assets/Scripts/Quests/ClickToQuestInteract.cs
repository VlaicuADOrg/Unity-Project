using UnityEngine;
using UnityEngine.EventSystems;

public class ClickToQuestInteract : MonoBehaviour
{
    [SerializeField] private Camera cam;
    [SerializeField] private LayerMask interactMask = ~0;
    [SerializeField] private float maxDistance = 200f;

    private void Reset()
    {
        cam = Camera.main;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // dacă dai click pe UI, ignoră
            if (EventSystem.current != null && EventSystem.current.IsPointerOverGameObject())
                return;

            // dacă popup e deschis, nu interacționa iar
            if (QuestPopupUI.I != null && QuestPopupUI.I.IsOpen)
                return;

            var ray = cam.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out var hit, maxDistance, interactMask))
            {
                var giver = hit.collider.GetComponentInParent<QuestGiver>();
                if (giver != null)
                    giver.OnLeftClick();
            }
        }
    }
}
