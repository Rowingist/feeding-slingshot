using System;
using UnityEngine;

public class Fighter : MonoBehaviour
{
    private int _eatenFoodQuality;
    private float _elapsedTime;
    private float _foodPerSecond, _eatenFoodQuantity;

    public event Action EatenFreshFood;
    public event Action EatenSpoiledFood;
    public event Action StartedPush;
    public event Action Won;
    public event Action Lost;

    public int PlayPoints { get; private set; }

    public int EatenFoodQuality => _eatenFoodQuality;

    private void Update()
    {
        _elapsedTime += Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out FreshFood freshFood))
        {
            PlayPoints += 10;
            _eatenFoodQuality = 1;
            EatenFreshFood?.Invoke();
        }
        
        if(other.TryGetComponent(out SpoiledFood spoiledFood))
        {
            if(PlayPoints >= 5)
                PlayPoints -= 5;

            _eatenFoodQuality = 0;
            EatenSpoiledFood?.Invoke();
        }

        if (other.TryGetComponent(out MoverSwitch pushingArea))
        {
            StartedPush?.Invoke();
        }

        if (other.TryGetComponent(out KillZone killZone))
        {
            Lost?.Invoke();
        }
    }

    //private float GetAmountPerOneSecond 

    public void SetWinState()
    {
        Won?.Invoke();
    }

    public void SetLoseStae()
    {
        Lost?.Invoke();
    }
}