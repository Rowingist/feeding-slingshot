using UnityEngine;

public class Parabola2D 
{ 
    public float CoefficientA { get; private set; }
    public float CoefficientB { get; private set; }
    public float CoefficientC { get; private set; }
    public Vector2 RangeOfFunction { get; private set; }
    public float Length { get; private set; }

    public Parabola2D(float ñoefficientA, float ñoefficientB, float ñoefficientC, float length)
    {
        CoefficientA = ñoefficientA;
        CoefficientB = ñoefficientB;
        CoefficientC = ñoefficientC;

        SetFunctionRange();
        Length = length;
    }

    public Parabola2D(Vector2 a, Vector2 b, Vector2 c)
    {
        var divisor = (a.x - b.x) * (a.x - c.x) * (c.x - b.x);

        if (divisor == 0f)
        {
            a.x += 0.00001f;
            b.x += 0.00002f;
            c.x += 0.00003f;
            divisor = (a.x - b.x) * (a.x - c.x) * (c.x - b.x);
        }

        CoefficientA = (a.x * (b.y - c.y) + b.x * (c.y - a.y) + c.x * (a.y - b.y)) / divisor;
        CoefficientB = (a.x * a.x * (b.y - c.y) + b.x * b.x * (c.y - a.y) + c.x * c.x * (a.y - b.y)) / divisor * -1f;
        CoefficientC = (a.x * a.x * (b.x * c.y - c.x * b.y) + a.x * (c.x * c.x * b.y - b.x * b.x * c.y) + b.x * c.x * a.y * (b.x - c.x)) / divisor;

        SetFunctionRange();
        Length = Vector2.Distance(a, c);
    }

    public float GetFunctionResult(float x)
    {
        return CoefficientA * x * x + CoefficientB * x + CoefficientC;
    }

    private void SetFunctionRange()
    {
        var extremum = -CoefficientB / (2 * CoefficientA);
        RangeOfFunction = new Vector2(extremum, GetFunctionResult(extremum));
    }
}