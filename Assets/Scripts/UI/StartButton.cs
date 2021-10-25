using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class StartButton : MonoBehaviour, IPointerDownHandler
{
    public event Action Pushed;

    public void OnPointerDown(PointerEventData eventData)
    {
        Pushed?.Invoke();
        gameObject.SetActive(false);
    }
}