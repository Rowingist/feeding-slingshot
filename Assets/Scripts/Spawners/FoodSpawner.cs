using UnityEngine;

public class FoodSpawner : ObjectPool
{
    [SerializeField] private GameObject[] _prefabs;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private Transform[] _flightPathRoots;
    [SerializeField] private LineRenderer _lineRenderer;
    [SerializeField] private Transform _slingshotRubber;

    private PlayerInput _mouseService;
    private Vector3 _mouseStartPostion;

    private void Awake()
    {
        _mouseService = GetComponent<PlayerInput>();
        Initialize(_prefabs);
    }

    private void OnEnable()
    {
        _mouseService.LeftButtonStartPositionSet += SetAimStartPosition;
        _mouseService.Dragging += Spawn;
    }

    private void OnDisable()
    {
        _mouseService.LeftButtonStartPositionSet -= SetAimStartPosition;
        _mouseService.Dragging -= Spawn;
    }

    public void Spawn()
    {
        if (TryGetRandomObject(out GameObject foodPrefab))
        {
            if (foodPrefab.TryGetComponent(out Food food))
            {
                SetFood(food, _spawnPoint.position);
            }

            if (foodPrefab.TryGetComponent(out FlightPath flightPath))
            {
                flightPath.InitFlightPathRoots(_flightPathRoots);
            }

            if (foodPrefab.TryGetComponent(out PathChanger pointerMover ))
            {
                pointerMover.enabled = true;
                pointerMover.SetMouseStartPosition(_mouseStartPostion);
            }

            if(foodPrefab.TryGetComponent(out PathRenderer pathRenderer))
            {
                _lineRenderer.enabled = true;
                pathRenderer.enabled = true;
                pathRenderer.SetLineRenderer(_lineRenderer);
            }
        }
    }

    private void SetFood(Food food, Vector3 spawnPoint)
    {
        if (GetSpawnPermition())
            return;

        food.InitSlingshotRuberPosition(_slingshotRubber.position);
        food.transform.position = spawnPoint;
        food.gameObject.SetActive(true);
    }

    private void SetAimStartPosition(Vector3 newPosition)
    {
        _mouseStartPostion = newPosition;
    }
}