using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;
    [SerializeField] private Transform[] _flightPathRoots;

    private FlightPath _enemyFlightPath;
    private float _instantTime = float.MaxValue;
    private float _elapsedTime = 0f;
    private float _timeBetweenShoot = 4f;

    private void Awake()
    {
        _enemyFlightPath = GetComponent<FlightPath>();
    }

    private void Start()
    {
        _enemyFlightPath.InitFlightPathRoots(_flightPathRoots);
    }

    private void Update()
    {
        _elapsedTime += Time.deltaTime;
        if(_elapsedTime >= _timeBetweenShoot)
        {
            _elapsedTime = 0f;
            _enemyFlightPath.MoveHighestPointTo(new Vector3(Random.Range(-5f, 5f), Random.Range(1f, 7f), 0));
            _instantTime = 0f;
        }
    }

    private void FixedUpdate()
    {
        if (_instantTime < _enemyFlightPath.Lenght)
        {
            _instantTime += Time.deltaTime * _speed;
            transform.position = _enemyFlightPath.GetPositionForPoint(_instantTime);
        }
    }
}