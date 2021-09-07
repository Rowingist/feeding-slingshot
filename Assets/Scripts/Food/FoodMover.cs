using UnityEngine;

public class FoodMover : MonoBehaviour
{
    [SerializeField] private float _speed = 1f;

    private FlightPath _flightPath;
    private float _instantTime = float.MaxValue;

    private void Awake()
    {
        _flightPath = GetComponent<FlightPath>();
    }

    private void OnEnable()
    {
        _instantTime = 0f;
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        if (_instantTime < _flightPath.Lenght)
        {
            _instantTime += Time.deltaTime * _speed;
            transform.position = _flightPath.GetPositionForPoint(_instantTime);
        }
    }
}