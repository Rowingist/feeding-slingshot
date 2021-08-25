using UnityEngine;
using Zenject;

public class PathRenderer : MonoBehaviour
{
    private LineRenderer _lineRenderer;
    private FoodMover _foodMover;

    private int _parabolaResolution = 50;

    [Inject]
    private void Construct(LineRenderer lineRenderer)
    {
        _lineRenderer = lineRenderer;
    }

    private void Start()
    {
        _foodMover = GetComponent<FoodMover>();
    }

    private void Update()
    {
        _foodMover.FlightPath.MakeParabola3D(1f);
        if ((_foodMover.FlightPath.GetPointsLength() - 1) % 2 != 0)
            return;

        _lineRenderer.positionCount = _parabolaResolution;

        Vector3 previousPososition = _foodMover.FlightPath.GetPointPosition(0);

        for (int i = 0; i < _parabolaResolution; i++)
        {
            float currentTime = i * _foodMover.FlightPath.Lenght / _parabolaResolution;
            Vector3 currentPosition = _foodMover.FlightPath.GetPositionAtTime(currentTime);
            _lineRenderer.SetPosition(i, previousPososition);
            previousPososition = currentPosition;
        }
    }
}
