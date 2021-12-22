using System;
using System.Collections;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private Camera _mainCamera;
    private Vector2 _startTouchPosition, _rightSideDirection, _leftSideDirection;
    private bool _isRightAiming;
    private bool _isLeftAiming;

    public event Action<Vector2> ScreenSideChosen;
    public event Action TouchPerformed;

    private void Start()
    {
        _mainCamera = Camera.main;
        _rightSideDirection = new Vector2(0.6f, 0);
        _leftSideDirection = new Vector2(0.4f, 0);
    }

    private void Update()
    {
        ChoseScreenSide();

        if (Input.GetMouseButtonUp(0))
        {
            TouchPerformed?.Invoke();
        }
    }

    private void ChoseScreenSide()
    {
        Vector2 viewPortTouchPosition = _mainCamera.ScreenToViewportPoint(Input.mousePosition);

        if (Input.GetMouseButtonDown(0))
        {
            _startTouchPosition = _mainCamera.ScreenToViewportPoint(Input.mousePosition);
        }

        if (Input.GetMouseButton(0))
        {
            _isLeftAiming = viewPortTouchPosition.x < _startTouchPosition.x;
            _isRightAiming = viewPortTouchPosition.x > _startTouchPosition.x;
        }
        else if (Mathf.Approximately(viewPortTouchPosition.x, _startTouchPosition.x))
        {
            _isLeftAiming = _isRightAiming = false;
        }

        if (Input.GetMouseButtonUp(0))
        {
            if (_isLeftAiming)
            {
                ScreenSideChosen?.Invoke(_leftSideDirection);
            }
            else if (_isRightAiming)
            {
                ScreenSideChosen?.Invoke(_rightSideDirection);
            }
            else
            {
                ScreenSideChosen?.Invoke(viewPortTouchPosition);
            }
        }
    }
}