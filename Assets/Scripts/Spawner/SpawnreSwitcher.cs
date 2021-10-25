using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnreSwitcher : MonoBehaviour
{
    [SerializeField] private CountdownTimer _startTimer;
    [SerializeField] private GameObject _objectToSwitch;

    private void OnEnable()
    {
        _startTimer.GameStarted += OnSwitch;
    }

    private void OnDisable()
    {
        _startTimer.GameStarted -= OnSwitch;
    }

    private void OnSwitch()
    {
        _objectToSwitch.SetActive(true);
    }
}
