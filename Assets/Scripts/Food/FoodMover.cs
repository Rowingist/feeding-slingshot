using UnityEngine;

public class FoodMover : MonoBehaviour
{
    [SerializeField] private float _speed = 1f;

    private Transform[] _parabolaRoots;
    private Parabola3D _flightPath;

    private float _instantTime = float.MaxValue;

    private void OnEnable()
    {
        Vector3 pointA, pointB, pointC;
        pointA = _parabolaRoots[0].position;
        pointB = _parabolaRoots[1].position;
        pointC = _parabolaRoots[2].position;
        _flightPath = new Parabola3D(pointA, pointB, pointC);
        _instantTime = 0f;
    }

    private void Update()
    {
        if (_instantTime < _flightPath.Length)
        {
            _instantTime += Time.deltaTime * _speed;
            transform.position = _flightPath.GetPositionAtTime(_instantTime);
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, _parabolaRoots[2].position, _speed * Time.deltaTime); ;
        }
    }

    public void IntitParabolaRoots(Transform[] roots)
    {
        _parabolaRoots = roots;
    }
}