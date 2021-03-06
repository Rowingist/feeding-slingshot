using UnityEngine;

public class Parabola3D
{
    private Vector3 _coefficientA;
    private Vector3 _coefficientB;
    private Vector3 _coefficientC;
    private Vector3 _height;

    private Parabola2D _parabola2D;
    private bool _tooClose;

    public float Length { get; private set; }

    public Parabola3D(Vector3 a, Vector3 b, Vector3 c)
    {
        _coefficientA = a;
        _coefficientB = b;
        _coefficientC = c;

        RefreshCurve();
    }
    public Vector3 GetPositionAtTime(float builtLength)
    {
        Vector3 positionAtLength;
        float lengthsRelation = builtLength / Length;
        float x = lengthsRelation * (_coefficientC - _coefficientA).magnitude;

        if (_tooClose)
        {
            x = lengthsRelation * 2f;
        }

        positionAtLength = _coefficientA * (1f - lengthsRelation) + _coefficientC * lengthsRelation + _height.normalized * _parabola2D.GetFunctionResult(x);

        if (_tooClose)
        {
            positionAtLength.Set(_coefficientA.x, positionAtLength.y, _coefficientA.z);
        }

        return positionAtLength;
    }

    private void RefreshCurve()
    {
        float distanceAB = Vector2.Distance(new Vector2(_coefficientA.x, _coefficientA.z), new Vector2(_coefficientB.x, _coefficientB.z));
        float distanceBC = Vector2.Distance(new Vector2(_coefficientB.x, _coefficientB.z), new Vector2(_coefficientC.x, _coefficientC.z));
        _tooClose = distanceAB < 0.1f && distanceBC < 0.1f;

        Length = Vector3.Distance(_coefficientA, _coefficientB) + Vector3.Distance(_coefficientB, _coefficientC);

        if (!_tooClose)
        {
            RefreshCurveNormal();
        }
        else
        {
            RefreshCurveClose();
        }
    }

    private void RefreshCurveNormal()
    {
        Ray rayToClosestLine = new Ray(_coefficientA, _coefficientC - _coefficientA);
        Vector3 currentPoint = GetClosestPointInLine(rayToClosestLine, _coefficientB);

        Vector2 twoDimensionA, twoDimensionB, twoDimensionC;
        twoDimensionA.x = 0f;
        twoDimensionA.y = 0f;
        twoDimensionB.x = Vector3.Distance(_coefficientA, currentPoint);
        twoDimensionB.y = Vector3.Distance(_coefficientB, currentPoint);
        twoDimensionC.x = Vector3.Distance(_coefficientA, _coefficientC);
        twoDimensionC.y = 0f;

        _parabola2D = new Parabola2D(twoDimensionA, twoDimensionB, twoDimensionC);
        _height = (_coefficientB - currentPoint) / Vector3.Distance(currentPoint, _coefficientB) * _parabola2D.RangeOfFunction.y;
    }

    private void RefreshCurveClose()
    {
        Vector2 twoDimensionA, twoDimensionB, twoDimensionC;
        float fac01 = (_coefficientA.y <= _coefficientB.y) ? 1f : -1f;
        float fac02 = (_coefficientA.y <= _coefficientC.y) ? 1f : -1f;

        twoDimensionA.x = 0f;
        twoDimensionA.y = 0f;
        twoDimensionB.x = 1f;
        twoDimensionB.y = Vector3.Distance((_coefficientA + _coefficientC) / 2f, _coefficientB) * fac01;
        twoDimensionC.x = 2f;
        twoDimensionC.y = Vector3.Distance(_coefficientA, _coefficientC) * fac02;

        _parabola2D = new Parabola2D(twoDimensionA, twoDimensionB, twoDimensionC);
        _height = Vector3.up;
    }

    private Vector3 GetClosestPointInLine(Ray ray, Vector3 currentPoint)
    {
        return ray.origin + ray.direction * Vector3.Dot(ray.direction, currentPoint - ray.origin);
    }

    public void UpdateCoefficients(Vector3 a, Vector3 b, Vector3 c)
    {
        _coefficientA = a;
        _coefficientB = b;
        _coefficientC = c;
        RefreshCurve();
    }
}