using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System;

public class FoodSpawner : ObjectPool
{
    [SerializeField] private GameObject[] _prefabs;
    [SerializeField] private Sprite[] _prefabIcons;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private Image _sceneObjectIcon;
    [SerializeField] private Path _leftPath;
    [SerializeField] private Path _rightPath;
    [SerializeField] private float _timeToFly = 0.2f;

    private PlayerInput _playerInput;
    private Food _currentActivated, _nextActvated;

    private float _spawnTime, _deltaActivationTime;

    public event Action<int, bool, float> FoodActivated;

    private void Awake()
    {
        _playerInput = GetComponent<PlayerInput>();
        Initialize(_prefabs, _prefabIcons);
        SetNext();
        _currentActivated = _nextActvated;
        Spawn();
    }

    private void OnEnable()
    {
        _playerInput.TouchPerformed += Spawn;
    }

    private void OnDisable()
    {
        _playerInput.TouchPerformed -= Spawn;
    }

    private void Spawn()
    {
        _spawnTime = Time.time;

        if (_spawnTime > _currentActivated.ActivationTime)
        {
            _deltaActivationTime = GetTimeBetweenActivation(_spawnTime, _currentActivated.ActivationTime);
            FoodActivated?.Invoke(_currentActivated.PathSideIndex, _currentActivated.IsSpoiled,_timeToFly);
        }

        if (TryGetObject(out GameObject foodPrefab))
        {
            if (foodPrefab.TryGetComponent(out Food food))
            {
                food.enabled = true;
                SetFood(food, _spawnPoint.position);
                _currentActivated = food;
                food.InitPossiblePaths(_leftPath, _rightPath);
            }

            _sceneObjectIcon.enabled = true;
            DepictNextFoodIcon();
            SetNext();
        }
    }

    private void SetFood(Food food, Vector3 spawnPoint)
    {
        Vector3 targetScale = food.transform.localScale;
        Vector3 startScale = Vector3.zero;

        food.transform.localScale = startScale;
        food.transform.position = spawnPoint;
        food.SetActivationTime(Time.time);
        food.gameObject.SetActive(true);
        food.transform.DOScale(targetScale, 0.5f);
    }

    private void DepictNextFoodIcon()
    {
        _sceneObjectIcon.sprite = TryGetObject();
    }

    public float GetTimeBetweenActivation(float spawntime, float activationTime)
    {
        return  spawntime - activationTime;
    }

    private void SetNext()
    {
        if (GetNextObject().TryGetComponent(out Food nextFood))
        {
            _nextActvated = nextFood;
        }
    }
}