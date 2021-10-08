using System;
using UnityEngine;
using UnityEngine.UI;

public class StartButton : MonoBehaviour
{
    [SerializeField] private GameObject _startButton;

    public event Action GameStarted;

    public void OnButtonClick()
    {
        GameStarted?.Invoke();
        _startButton.SetActive(false);
    }
}