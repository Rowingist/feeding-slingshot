using UnityEngine;
using Zenject;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed = 1f;
    [SerializeField] private Transform[] _points;

    private Transform _pathHighestPoint;
    private FlightPath _enemyFlightPath;

    private float _instantTime;

    private void Awake()
    {
        _enemyFlightPath = new FlightPath(_points);
        _pathHighestPoint = _points[1];
        _pathHighestPoint.transform.position += new Vector3(3, 4, 0);
        _enemyFlightPath.MakeParabola3D(1f);
    }

    private void Update()
    {
        if (_instantTime < _enemyFlightPath.Lenght)
        {
            _instantTime += Time.deltaTime * _speed;
            transform.position = _enemyFlightPath.GetPositionAtTime(_instantTime);
        }
    }

    private void OnBackToStart()
    {
        RefreshPosition();
    }

    private void OnStartMoving()
    {
        _instantTime = 0;
    }

    public void RefreshPosition()
    {
        _instantTime = 0f;
        transform.position = _enemyFlightPath.GetPointPosition(0);
    }
}