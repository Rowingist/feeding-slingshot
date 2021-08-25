using UnityEngine;
using UnityEngine.Events;

public class PlayerInput : MonoBehaviour, IMouseService
{
    public event UnityAction MouseLeftButtonPressed;
    public event UnityAction MouseLeftButtonReleased;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
            MouseLeftButtonPressed?.Invoke();

        if (Input.GetMouseButtonUp(0))
            MouseLeftButtonReleased?.Invoke();
    }
}
