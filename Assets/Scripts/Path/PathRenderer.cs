using UnityEngine;

[RequireComponent(typeof(FlightPath), typeof(PlayerInput))]
public class PathRenderer : MonoBehaviour
{
    private FlightPath _flightPath;
    private PlayerInput _playerInput;
    private LineRenderer _lineRenderer;

    private Vector3 _currentPosition, _previousPososition;

    private int _parabolaResolution = 50;

    private void Awake()
    {
        _flightPath = GetComponent<FlightPath>();
        _playerInput = GetComponent<PlayerInput>();
    }

    private void OnEnable()
    {
        _playerInput.LeftButtonReleased += OnDeactivateLine;
    }

    private void OnDisable()
    {
        _playerInput.LeftButtonReleased -= OnDeactivateLine;
    }

    private void Update()
    {
        SetPositionCount(_parabolaResolution);
        Render();
    }

    private void SetPositionCount(int resolution)
    {
        _lineRenderer.positionCount = resolution;
    }

    private void Render()
    {
        _previousPososition = _flightPath.GetPointPosition(0);
        SetLineColor(Color.white);

        for (int i = 0; i < _parabolaResolution; i++)
        {
            float currentPoint = i * _flightPath.Lenght / _parabolaResolution;
            _currentPosition = _flightPath.GetPositionForPoint(currentPoint);
            HitIntoAim();
            _lineRenderer.SetPosition(i, _previousPososition);
            _previousPososition = _currentPosition;
        }
    }

    private void HitIntoAim()
    {
        Ray ray = new Ray(_currentPosition, Vector3.forward);
        if (Physics.Raycast(ray, out RaycastHit hit, 1, ~9))
        {
            SetLineColor(Color.green);
        }
    }

    private void SetLineColor(Color color)
    {
        _lineRenderer.startColor = color;
        _lineRenderer.endColor = color;
    }

    private void OnDeactivateLine()
    {
        _lineRenderer.enabled = false;
    }

    public void SetLineRenderer(LineRenderer lineRenderer)
    {
        _lineRenderer = lineRenderer;
    }

    public void ResetLine()
    {
        _lineRenderer.positionCount = 0;
        _flightPath.MoveHighestPointTo(Vector3.zero);
    }
}
