using System.Collections.Generic;
using UnityEngine;

public class FlightPath : Points
{
    private Transform[] _points;
    private Parabola3D[] _parabolas;
    private float[] _parabolaParts;

    public float Lenght { get; private set; }

    public FlightPath(Transform[] points)
    {
        _points = points;

        if ((points.Length - 1) % 2 != 0)
        {
            throw new UnityException("ParabolaRoot needs odd number of points");
        }

        int halfPoints = (points.Length - 1) / 2;

        if (_parabolas == null || _parabolas.Length < halfPoints)
        {
            _parabolas = new Parabola3D[halfPoints];
            _parabolaParts = new float[_parabolas.Length];
        }
    }

    public Vector3 GetPositionAtTime(float time)
    {
        var percent = time / _parabolaParts[0];
        return _parabolas[0].GetPositionAtLength(percent * _parabolas[0].Length);
    }

    public void MakeParabola3D(float speed)
    {
        if (_parabolas == null)
        {
            return;
        }

        Lenght = 0;

        Vector3 pointA, pointB, pointC;
        for (int i = 0; i < _parabolas.Length; i++)
        {
            pointA = _points[i * 2].position;
            pointB = _points[i * 2 + 1].position;
            pointC = _points[i * 2 + 2].position;
            _parabolas[i] = new Parabola3D(pointA, pointB, pointC);
            _parabolaParts[i] = _parabolas[i].Length / speed;
            Lenght += _parabolaParts[i];
        }
    }

    public Vector3 GetPointPosition(int pointIndex)
    {
        return _points[pointIndex].position;
    }

    public int GetPointsLength()
    {
        return _points.Length;
    }
}