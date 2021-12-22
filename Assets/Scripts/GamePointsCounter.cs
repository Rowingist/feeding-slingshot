using System;
using UnityEngine;

public class GamePointsCounter : MonoBehaviour
{
    [SerializeField] private FighterFastMover _fighterFastMover;
    [SerializeField] private Fighter _player;
    [SerializeField] private Fighter _enemy;

    public int CurrentPoints { get; private set; }

    public event Action GameWasWon;
    public event Action GameWasLost;

    private void OnEnable()
    {
        _fighterFastMover.KillingZoneReached += OnDeterminGameEnd;
    }

    private void OnDisable()
    {
        _fighterFastMover.KillingZoneReached -= OnDeterminGameEnd;
    }

    private void OnDeterminGameEnd(float killingSide)
    {
        if (killingSide > 0)
        {
            GameWasLost?.Invoke();
        }
        else
        { 
            GameWasWon?.Invoke();
        }
    }
}