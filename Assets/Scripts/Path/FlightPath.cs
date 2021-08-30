using UnityEngine;
using Zenject;

public class FlightPath : MonoBehaviour
{
    [SerializeField] private Transform[] _parabolaRoots;

    private Parabola3D[] _parabolas;
    private float[] _parabolaParts;

    public float Lenght { get; private set; }

    private void Awake()
    {
        MakeParabola3D();
    }

    private void Update()
    {
        MakeParabola3D();
    }

    public void MakeParabola3D()
    {
        if ((_parabolaRoots.Length - 1) % 2 != 0)
        {
            throw new UnityException("ParabolaRoot needs odd number of points");
        }

        int halfPoints = (_parabolaRoots.Length - 1) / 2;

        if (_parabolas == null || _parabolas.Length < halfPoints)
        {
            _parabolas = new Parabola3D[halfPoints];
            _parabolaParts = new float[_parabolas.Length];
        }

        if (_parabolas == null)
        {
            return;
        }

        Lenght = 0;

        Vector3 pointA, pointB, pointC;
        for (int i = 0; i < _parabolas.Length; i++)
        {
            pointA = _parabolaRoots[i * 2].position;
            pointB = _parabolaRoots[i * 2 + 1].position;
            pointC = _parabolaRoots[i * 2 + 2].position;
            _parabolas[i] = new Parabola3D(pointA, pointB, pointC);
            _parabolaParts[i] = _parabolas[i].Length;
            Lenght += _parabolaParts[i];
        }
    }

    public Vector3 GetPositionAtTime(float time)
    {
        var percent = time / _parabolaParts[0];
        return _parabolas[0].GetPositionAtLength(percent * _parabolas[0].Length);
    }

    public Vector3 GetPointPosition(int pointIndex)
    {
        return _parabolaRoots[pointIndex].position;
    }
}