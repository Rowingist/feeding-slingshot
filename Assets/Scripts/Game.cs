using System;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField, Range(1, 100)] private int _startEatenAmount = 15;
    [SerializeField] private Transform _platformLength;
    [SerializeField] private Fighter _player;
    [SerializeField] private Fighter _enemy;
    [SerializeField] private StartButton _startButton;
    [SerializeField] private FoodSpawner _foodSpawner;

    private int _maxEatenAmount;

    public int Points { get; private set; }
    public float FighterStepSize => _platformLength.localScale.x * 0.25f / _startEatenAmount;

    public event Action Over;
    public event Action SteppedLeft;
    public event Action SteppedRight;

    private void OnEnable()
    {
        _player.EatenFreshFood += OnIncreacePoins;
        _player.EatenSpoiledFood += OnDecreacePoints;
        _enemy.EatenFreshFood += OnDecreacePoints;
        _enemy.EatenSpoiledFood += OnIncreacePoins;
        _startButton.GameStarted += OnActivateFoodSpawner;
    }

    private void Start()
    {
        Points = _startEatenAmount;
        _maxEatenAmount = _startEatenAmount * 2;
    }

    private void OnDisable()
    {
        _player.EatenFreshFood -= OnIncreacePoins;
        _player.EatenSpoiledFood -= OnDecreacePoints;
        _enemy.EatenFreshFood -= OnDecreacePoints;
        _enemy.EatenSpoiledFood -= OnIncreacePoins;
        _startButton.GameStarted -= OnActivateFoodSpawner;
    }

    private void OnIncreacePoins()
    {
        Points++;

        if (Points == _maxEatenAmount)
        {
            Over?.Invoke();
        }
        else
        {
            SteppedRight?.Invoke();
        }
    }

    private void OnDecreacePoints()
    {
        Points--;

        if (Points <= 0)
        {
            Over?.Invoke();
        }
        else
        {
            SteppedLeft?.Invoke();
        }
    }

    private void OnActivateFoodSpawner()
    {
        _foodSpawner.gameObject.SetActive(true);
    }
}