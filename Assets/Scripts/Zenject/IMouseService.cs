using UnityEngine.Events;
using UnityEngine;

public interface IMouseService
{
    event UnityAction LeftButtonPressed;
    event UnityAction LeftButtonReleased;
    event UnityAction Dragging;
    event UnityAction AppropriateMagnitudeReached;

    Vector3 GetDeltaMousePosition();
    bool GetAmingPermition();
}