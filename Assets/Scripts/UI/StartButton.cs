using System;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class StartButton : MonoBehaviour, IPointerDownHandler
{
    public event Action Pushed;

    public void OnPointerDown(PointerEventData eventData)
    {
        Pushed?.Invoke();
        StartCoroutine(Deactivate(0.5f));
    }

    private IEnumerator Deactivate(float delay)
    {
        yield return new WaitForSeconds(delay);
        gameObject.SetActive(false);
    }
}