using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed = 1f;
    [SerializeField] private Transform[] _points;
    [SerializeField] private FlightPath _enemyFlightPath;
    [SerializeField] private Game _game;

    private Transform _pathHighestPoint;

    private float _instantTime;
    private float _elapsedTime = 0f;
    private float _timeBetweenShoot = 2f;

    private void Awake()
    {
        _enemyFlightPath.MakeParabola3D();
        _pathHighestPoint = _points[1];
    }

    private void OnEnable()
    {
        _game.GameOver += OnDeactivate;
    }

    private void OnDisable()
    {
        _game.GameOver += OnDeactivate;
    }

    private void Update()
    {
        if (_instantTime < _enemyFlightPath.Lenght)
        {
            _instantTime += Time.deltaTime * _speed;
            transform.position = _enemyFlightPath.GetPositionAtTime(_instantTime);
        }
        else
        {
            transform.position = _enemyFlightPath.GetPositionAtTime(0);
        }

        _elapsedTime += Time.deltaTime;
        if(_elapsedTime >= _timeBetweenShoot)
        {
            _elapsedTime = 0f;
            RefreshPosition();
            _pathHighestPoint.position = new Vector3(Random.Range(-5f, 5f), Random.Range(1f, 7f), 0);
            _enemyFlightPath.MakeParabola3D();
        }
    }

    public void RefreshPosition()
    {
        _instantTime = 0f;
    }

    private void OnDeactivate()
    {
        gameObject.SetActive(false);
    }
}