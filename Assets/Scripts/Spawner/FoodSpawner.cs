using UnityEngine;
using UnityEngine.UI;

public class FoodSpawner : ObjectPool
{
    [SerializeField] private GameObject[] _prefabs;
    [SerializeField] private Sprite[] _prefabIcons;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private Image _sceneObjectIcon;
    [SerializeField] private Path _leftPath;
    [SerializeField] private Path _rightPath;

    private PlayerInput _playerInput;
    private Food _currentSpawn;

    private void Awake()
    {
        _playerInput = GetComponent<PlayerInput>();
        Initialize(_prefabs, _prefabIcons);
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
        _sceneObjectIcon.enabled = true;
        if (TryGetObject(out GameObject foodPrefab))
        {
            if (foodPrefab.TryGetComponent(out Food food))
            {
                food.enabled = true;
                SetFood(food, _spawnPoint.position);
                food.InitPossiblePaths(_leftPath, _rightPath);
                _currentSpawn = food;
            }

            DepictNextFoodIcon();
        }
    }

    private void SetFood(Food food, Vector3 spawnPoint)
    {
        food.transform.position = spawnPoint;
        food.gameObject.SetActive(true);
    }

    private void DepictNextFoodIcon()
    {
        _sceneObjectIcon.sprite = TryGetObject();
    }

    public Vector3 GetSpawnedFoodPosition()
    {
        return _currentSpawn.transform.position;
    }
}