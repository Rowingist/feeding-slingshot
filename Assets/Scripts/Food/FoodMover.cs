using UnityEngine;
using Zenject;

public class FoodMover : MonoBehaviour
{
    [SerializeField] private float _speed = 1f;
    [SerializeField] private FlightPath _flightPath;
    [SerializeField] private PointerMover _pointerMover;
    [SerializeField] private FoodSpawner _foodSpawner;

    private GameObject _spawnedFood;

    private float _instantTime = 10f;

    private IMouseService _mouseService;

    [Inject]
    private void Construct(IMouseService mouseService)
    {
        _mouseService = mouseService;
    }

    private void OnEnable()
    {
        _mouseService.LeftButtonReleased += OnStartMoving;
    }

    private void FixedUpdate()
    {
        if (_instantTime < _flightPath.Lenght)
        {
            _foodSpawner.enabled = false;
            _pointerMover.enabled = false;
            _instantTime += Time.deltaTime * _speed;
            _spawnedFood.transform.position = _flightPath.GetPositionAtTime(_instantTime);
        }
        else
        {
            _foodSpawner.enabled = true;
            _pointerMover.enabled = true;
        }
    }

    private void OnDisable()
    {
        _mouseService.LeftButtonReleased -= OnStartMoving;
    }

    public void OnStartMoving()
    {
        _instantTime = 0;
    }

    public void SetMovingObject(GameObject food)
    {
        _spawnedFood = food;
    }
}
