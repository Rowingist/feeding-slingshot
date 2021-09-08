using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerInput : MonoBehaviour
{
    private Vector3 _mousePressedPosition;
    private Vector3 _deltaMousePosition;

    public event Action<Vector3> LeftButtonStartPositionSet;
    public event Action LeftButtonReleased;
    public event Action Dragging;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _mousePressedPosition = Input.mousePosition;
            LeftButtonStartPositionSet?.Invoke(_mousePressedPosition);
        }
                
        _deltaMousePosition = Input.mousePosition - _mousePressedPosition;

        if (_deltaMousePosition.magnitude > 100 && _deltaMousePosition.magnitude < 200 && Input.GetMouseButton(0))
        {
            Dragging?.Invoke();
        }

        if (Input.GetMouseButtonUp(0))
        {
            LeftButtonReleased?.Invoke();
        }
    }
}