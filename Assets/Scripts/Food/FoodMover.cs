using UnityEngine;
using Zenject;

public class FoodMover : MonoBehaviour
{
    [SerializeField] private float _speed = 1f;

    private Transform[] _points;
    private FlightPath _flightPath;
    private IMouseService _mouseService;

    private float _instantTime;

    public FlightPath FlightPath => _flightPath;

    public bool IsMoving { get; private set; }

    [Inject]
    private void Construct(IMouseService mouseService)
    {
        _mouseService = mouseService;
        _mouseService.MouseLeftButtonPressed += OnBackToStart;
        _mouseService.MouseLeftButtonReleased += OnStartMoving;
    }

    [Inject]
    private void Construct(Transform[] parabolaRoots)
    {
        _points = parabolaRoots;
    }

    private void Awake()
    {
        _flightPath = new FlightPath(_points);
    }

    private void FixedUpdate()
    {
        if (IsMoving && _instantTime < _flightPath.Lenght)
        {
            _instantTime += Time.deltaTime * _speed;
            transform.position = _flightPath.GetPositionAtTime(_instantTime);
        }
    }

    private void OnDisable()
    {
        _mouseService.MouseLeftButtonPressed -= OnBackToStart;
        _mouseService.MouseLeftButtonReleased -= OnStartMoving;
    }

    private void OnBackToStart()
    {
        RefreshPosition();
        IsMoving = false;
    }

    private void OnStartMoving()
    {
        IsMoving = true;
        _instantTime = 0;
    }

    public void RefreshPosition()
    {
        _instantTime = 0f;
        transform.position = _flightPath.GetPointPosition(0);
    }
}
