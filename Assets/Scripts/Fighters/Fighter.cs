using System;
using UnityEngine;

public class Fighter : MonoBehaviour
{
    [SerializeField] private Game _game;

    public event Action EatenFreshFood;
    public event Action EatenSpoiledFood;
    public event Action StartedPush;
    public event Action Won;
    public event Action Lost;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out FreshFood freshFood))
        {
            EatenFreshFood?.Invoke();
        }
        else if(other.TryGetComponent(out SpoiledFood spoiledFood))
        {
            EatenSpoiledFood?.Invoke();
        }

        if(other.TryGetComponent(out PushingArea pushingArea))
        {
            StartedPush?.Invoke();
            pushingArea.gameObject.SetActive(false);
        }
    }

    private void OnEnable()
    {
        _game.Over += OnInvokeGameOverAction;
    }

    private void OnDisable()
    {
        _game.Over -= OnInvokeGameOverAction;
    }

    private void OnInvokeGameOverAction()
    {
        if (_game.Points > 0)
            Won?.Invoke();
        else
            Lost?.Invoke();
    }
}