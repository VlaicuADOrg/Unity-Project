using UnityEngine;
using UnityEngine.EventSystems;

public class LiftButtonTwoWay : MonoBehaviour
{
    public enum ActionType { Up, Down }
    [SerializeField] private LiftPlatform lift;
    [SerializeField] private ActionType action = ActionType.Up;

    private void OnMouseDown()
    {
        if (EventSystem.current != null && EventSystem.current.IsPointerOverGameObject())
            return;

        OnLeftClick();
    }

    public void OnLeftClick()
    {
        if (lift == null) return;
        if (action == ActionType.Up) lift.GoUp();
        else lift.GoDown();
    }
}
