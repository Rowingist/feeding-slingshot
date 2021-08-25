using UnityEngine.Events;

public interface IMouseService
{
    event UnityAction MouseLeftButtonPressed;
    event UnityAction MouseLeftButtonReleased;
}