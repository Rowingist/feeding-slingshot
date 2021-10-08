using UnityEngine;

public class Path : MonoBehaviour
{
    private PlayerInput _playerInput;
    private Transform[] _playerPathPoints;
    private Transform[] _enemyPathPoints;
    private Transform[] _parabolaRoots;
    private Parabola3D _parabola;

    private float _progibitedPathHeight = 0.75f;
    private float _middleOfSscreen = 0.5f;

    public float Lenght => _parabola.Length;

    private void Awake()
    {
        _playerInput = GetComponentInParent<PlayerInput>();
    }

    private void OnEnable()
    {
        _playerInput.ScreenSideChosen += OnSetPathSide;
    }

    private void OnDisable()
    {
        _playerInput.ScreenSideChosen -= OnSetPathSide;
    }

    public void MakeParabola3D()
    {
        if (_parabolaRoots.Length % 2 == 0)
        {
            throw new UnityException("ParabolaRoot needs odd number of points");
        }

        Vector3 pointA, pointB, pointC;
        pointA = _parabolaRoots[0].position;
        pointB = _parabolaRoots[1].position;
        pointC = _parabolaRoots[2].position;
        _parabola = new Parabola3D(pointA, pointB, pointC);
    }

    public Vector3 GetPositionForPoint(float instantTime)
    {
        return _parabola.GetPositionAtTime(instantTime * Lenght);
    }

    public Vector3 GetPointPosition(int pointIndex)
    {
        return _parabolaRoots[pointIndex].position;
    }

    private void OnSetPathSide(Vector2 detouchViewPortPosition)
    {
        bool isOnAppropriatetHeight = detouchViewPortPosition.y < _progibitedPathHeight;
        bool isOnLeftSideOfscreen = detouchViewPortPosition.x < _middleOfSscreen;

        if (!isOnLeftSideOfscreen && isOnAppropriatetHeight)
            _parabolaRoots = _enemyPathPoints;
        else if (isOnLeftSideOfscreen && isOnAppropriatetHeight)
            _parabolaRoots = _playerPathPoints;
    }

    public void InitPossiblePathPoints(Transform[] playerPathPoints, Transform[] enemyPathPoints)
    {
        _playerPathPoints = playerPathPoints;
        _enemyPathPoints = enemyPathPoints;
    }
}