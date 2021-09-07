using System;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private FighterSizeChanger _playerFighter;
    [SerializeField] private FighterSizeChanger _enemyFighter;

    public event Action Won;
    public event Action Over;

    private void OnEnable()
    {
        _playerFighter.Lost += OnOverState;
        _enemyFighter.Lost += OnWinState;
    }

    private void OnDisable()
    {
        _playerFighter.Lost -= OnOverState;
        _enemyFighter.Lost -= OnWinState;
    }

    private void OnWinState()
    {
        Won.Invoke();
    }

    private void OnOverState()
    {
        Over?.Invoke();
    }
}