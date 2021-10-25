using System;
using System.Collections;
using UnityEngine;

public class GamePointsCounter : MonoBehaviour
{
    [SerializeField, Range(1, 100)] private int _startPointsAmount = 15;
    [SerializeField] private Fighter _player;
    [SerializeField] private Fighter _enemy;

    public int StartPointsQuantity => _startPointsAmount;
    public int CurrentPoints { get; private set; }
    public int PointsQuantityToWin => _startPointsAmount * 2;

    public event Action GameWasWon;
    public event Action GameWasLost;
    public event Action PointsDecreased;
    public event Action PointsIncreased;

    private void Awake()
    {
        CurrentPoints = _startPointsAmount;
    }

    private void OnEnable()
    {
        _player.EatenFreshFood += OnIncreacePoins;
        _player.EatenSpoiledFood += OnDecreacePoints;
        _enemy.EatenFreshFood += OnDecreacePoints;
        _enemy.EatenSpoiledFood += OnIncreacePoins;
    }

    private void OnDisable()
    {
        _player.EatenFreshFood -= OnIncreacePoins;
        _player.EatenSpoiledFood -= OnDecreacePoints;
        _enemy.EatenFreshFood -= OnDecreacePoints;
        _enemy.EatenSpoiledFood -= OnIncreacePoins;
    }

    private void OnIncreacePoins()
    {
        CurrentPoints++;

        if (CurrentPoints == PointsQuantityToWin)
        {
            GameWasWon?.Invoke();
            _player.SetWinState();
            _enemy.SetLoseStae();
        }

        PointsIncreased?.Invoke();
    }

    private void OnDecreacePoints()
    {
        CurrentPoints--;

        if (CurrentPoints <= 0)
        {
            GameWasLost?.Invoke();
            _enemy.SetWinState();
            _player.SetLoseStae();
        }

        PointsDecreased?.Invoke();
    }
}