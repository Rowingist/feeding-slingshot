using UnityEngine;
using Zenject;

public class PointerMover : MonoBehaviour
{
    [SerializeField] private Transform _highestParabolaPoint;
    [SerializeField, Range(1, 10)] private float _pointingMultilier;

    private IMouseService _mouseService;

    private Camera _mainCamera;
    private Vector3 _newHighestPointPosition;

    [Inject]
    private void Construct(IMouseService mouseService)
    {
        _mouseService = mouseService;
    }

    private void Start()
    {
        _mainCamera = Camera.main;
    }

    private void Update()
    {
        if (_mouseService.GetAmingPermition())
        {
            _newHighestPointPosition = -_mainCamera.ScreenToViewportPoint(_mouseService.GetDeltaMousePosition());
            _newHighestPointPosition.z = _highestParabolaPoint.position.z;
            _highestParabolaPoint.position = _newHighestPointPosition * _pointingMultilier;
        }
    }
}
