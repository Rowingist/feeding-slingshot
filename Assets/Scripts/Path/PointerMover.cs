using UnityEngine;
using Zenject;

public class PointerMover : MonoBehaviour
{
    [SerializeField] private GameObject _pathHighestPoint;
    [SerializeField] private GameObject _line;
    [SerializeField, Range(1, 10)] private float _pointingMultilier;
    [SerializeField, Range(0, 100)] private float _minDragToStartPointing;

    private FoodMover _foodMover;
    private IMouseService _mouseService;

    private Camera _mainCamera;
    private Vector3 _mousePressedPosition;
    private Vector3 _newPosition;
    private Vector3 _deltaMousePosition;

    [Inject]
    private void Construct(IMouseService mouseService)
    {
        _mouseService = mouseService;
        _mouseService.MouseLeftButtonPressed += OnSetCurrentMousePosition;
    }

    [Inject]
    private void Construct(FoodMover foodMover)
    {
        _foodMover = foodMover;
    }

    private void Start()
    {
        _mainCamera = Camera.main;
    }

    private void Update()
    {
        if (_mousePressedPosition != Vector3.zero)
        {
            _deltaMousePosition = Input.mousePosition - _mousePressedPosition;
        }

        if (_deltaMousePosition.magnitude > _minDragToStartPointing && !_foodMover.IsMoving)
        {
            _line.gameObject.SetActive(true);
            _newPosition = -_mainCamera.ScreenToViewportPoint(_deltaMousePosition);
            _newPosition.z = _pathHighestPoint.transform.position.z ;
            _pathHighestPoint.transform.position = _newPosition * _pointingMultilier;
        }
        else
        {
            _line.gameObject.SetActive(false);
        }
    }

    private void OnDisable()
    {
        _mouseService.MouseLeftButtonPressed -= OnSetCurrentMousePosition;
    }

    private void OnSetCurrentMousePosition()
    {
        _pathHighestPoint.transform.position = Vector3.zero;
        _mousePressedPosition = Input.mousePosition;
    }
}
