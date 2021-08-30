using UnityEngine;
using UnityEngine.Events;

public class PlayerInput : MonoBehaviour, IMouseService
{
    private Vector3 _mousePressedPosition;
    private Vector3 _deltaMousePosition;

    private bool _dragIsEnoughToAiming;
    private float _minDragMagnitude = 100f;

    public event UnityAction LeftButtonPressed;
    public event UnityAction LeftButtonReleased;
    public event UnityAction Dragging;
    public event UnityAction AppropriateMagnitudeReached;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            LeftButtonPressed?.Invoke();
            _mousePressedPosition = Input.mousePosition;
        }

        if (_mousePressedPosition != Vector3.zero)
        {
            _deltaMousePosition = Input.mousePosition - _mousePressedPosition;
        }

        _dragIsEnoughToAiming = _deltaMousePosition.magnitude > _minDragMagnitude;

        if (_deltaMousePosition.magnitude > 60 && _deltaMousePosition.magnitude < 100)
        {
            Dragging?.Invoke();
        }

        if (Input.GetMouseButtonUp(0) && _dragIsEnoughToAiming)
        {
            LeftButtonReleased?.Invoke();
        }
    }

    public Vector3 GetDeltaMousePosition()
    {
        return _deltaMousePosition;
    }

    public bool GetAmingPermition()
    {
        return Input.GetMouseButton(0) && _dragIsEnoughToAiming;
    }
}