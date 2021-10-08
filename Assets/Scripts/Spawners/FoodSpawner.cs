using UnityEngine;

public class FoodSpawner : ObjectPool
{
    [SerializeField] private GameObject[] _prefabs;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private Transform[] _playerPathPoints;
    [SerializeField] private Transform[] _enemyPathPoints;

    private PlayerInput _playerInput;

    private void Awake()
    {
        _playerInput = GetComponent<PlayerInput>();
        Initialize(_prefabs);
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

    public void Spawn()
    {
        if (TryGetObject(out GameObject foodPrefab))
        {
            if (foodPrefab.TryGetComponent(out Food food))
            {
                SetFood(food, _spawnPoint.position);
                food.InitPossiblePathPoints(_playerPathPoints, _enemyPathPoints);
            }
        }
    }

    private void SetFood(Food food, Vector3 spawnPoint)
    {
        food.transform.position = spawnPoint;
        food.gameObject.SetActive(true);
    }
}