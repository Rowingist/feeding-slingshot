using UnityEngine;
using Zenject;

public class FoodSpawner : ObjectPool
{
    [SerializeField] private GameObject[] _prefabs;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private FoodMover _foodMover;

    private IMouseService _mouseService;

    [Inject]
    private void Construct(IMouseService mouseService)
    {
        _mouseService = mouseService;
    }

    private void Awake()
    {
        Initialize(_prefabs);
    }

    private void Update()
    {
        if (_mouseService.GetAmingPermition())
            Spawn();
    }

    public void Spawn()
    {
        if (TryGetObject(out GameObject food, 0))
        {
            SetFood(food, _spawnPoint.position);
        }
    }

    private void SetFood(GameObject food, Vector3 spawnPoint)
    {
        if (GetSpawnPermition())
            return;

        food.transform.position = spawnPoint;
        food.SetActive(true);
        _foodMover.SetMovingObject(food);
    }
}
