using UnityEngine;

public class Path : MonoBehaviour
{
    [SerializeField] private Transform[] _pathRootPoints;

    private Parabola3D _flightTrajectory;

    public float Length => _flightTrajectory.Length;

    private void OnEnable()
    {
        Vector3 pointA, pointB, pointC;
        pointA = _pathRootPoints[0].position;
        pointB = _pathRootPoints[1].position;
        pointC = _pathRootPoints[2].position;
        _flightTrajectory = new Parabola3D(pointA, pointB, pointC);
    }

    private void Update()
    {
        _flightTrajectory.UpdateCoefficients(_pathRootPoints[0].position, _pathRootPoints[1].position, _pathRootPoints[2].position);
    }

    public Vector3 GetPositionAtTime(float instantTime)
    {
        return _flightTrajectory.GetPositionAtTime(instantTime);
    }

    public Vector3 GetStartPoint()
    {
        return _pathRootPoints[0].position;
    }
}
