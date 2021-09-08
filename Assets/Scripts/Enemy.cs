using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;
    [SerializeField] private Transform[] _flightPathRoots;

    private FlightPath _enemyFlightPath;
    private float _instantTime = float.MaxValue;
    private float _elapsedTime = 0f;
    private float _timeBetweenThrough = 4f;

    private void Awake()
    {
        _enemyFlightPath = GetComponent<FlightPath>();
    }

    private void Start()
    {
        _enemyFlightPath.InitFlightPathRoots(_flightPathRoots);
    }

    private void FixedUpdate()
    {
        ChangeMoveTrajectory();
        Move();
    }

    private void ChangeMoveTrajectory()
    {
        _elapsedTime += Time.deltaTime;
        if(_elapsedTime >= _timeBetweenThrough)
        {
            _elapsedTime = 0f;
            _instantTime = 0f;
            float _newPositionX = Random.Range(-5f, 5f);
            float _newPositionY = Random.Range(1f, 7f);
            Vector3 newTrajectoryMiddleRoot = new Vector3(_newPositionX, _newPositionY, 0f);
            _enemyFlightPath.MoveHighestPointTo(newTrajectoryMiddleRoot);
        }
    }

    private void Move()
    {
        if (_instantTime < _enemyFlightPath.Lenght)
        {
            _instantTime += Time.deltaTime * _speed;
            transform.position = _enemyFlightPath.GetPositionForPoint(_instantTime);
        }
    }
}