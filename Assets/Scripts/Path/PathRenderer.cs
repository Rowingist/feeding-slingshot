using UnityEngine;
using Zenject;

public class PathRenderer : MonoBehaviour
{
    [SerializeField] private FlightPath _flightPath;
    [SerializeField] private LineRenderer _lineRenderer;

    private int _parabolaResolution = 50;

    private IMouseService _mouseService;

    private Vector3 _previousPososition;
    private GameObject _aimingObject;

    [Inject]
    private void Construct(IMouseService mouseService)
    {
        _mouseService = mouseService;
    }

    private void Update()
    {
        if (_mouseService.GetAmingPermition())
        {
            _lineRenderer.positionCount = _parabolaResolution;

            _previousPososition = _flightPath.GetPointPosition(0);
            for (int i = 0; i < _parabolaResolution; i++)
            {
                float currentTime = i * _flightPath.Lenght / _parabolaResolution;
                Vector3 currentPosition = _flightPath.GetPositionAtTime(currentTime);
                _lineRenderer.SetPosition(i, _previousPososition);


                    _previousPososition = currentPosition;

            }
        }
    }
}
