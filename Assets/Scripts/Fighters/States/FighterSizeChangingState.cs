using System.Collections;
using UnityEngine;

public class FighterSizeChangingState : FighterBaseState
{
    private SkinnedMeshRenderer _shapeChanger;
    private float _scalingAmount;
    private float _scalingSpeed;
    private float _currentSize;

    public FighterSizeChangingState(Fighter fighter, IStationStateSwitcher stateSwitcher,
      SkinnedMeshRenderer shapeChanger, float scalingStep) : base(fighter, stateSwitcher)
    {
        _shapeChanger = shapeChanger;
        _scalingAmount = scalingStep;
        _scalingSpeed = 150f;
        _currentSize = _shapeChanger.GetBlendShapeWeight(2);
    }

    public override void Start()
    {
        ChangeSize();
        Stop();
    }

    public override void Stop()
    {
        _stateSwitcher.SwitchState<FighterPushingIdleState>();
    }

    public override void Idle()
    {

    }

    public override void Run()
    {
    }

    public override void StepBackwards()
    {
    }

    public override void Eat()
    {
    }

    public override void ChangeSize()
    {
        switch (_fighter.EatenFoodQuality)
        {
            case 1:
                Increase();
                break;
            case 0:
                Decrease();
                break;
        }
    }

    public override void PushForward()
    {
    }

    public override void Win()
    {
    }

    public override void Lose()
    {
    }

    private void Increase()
    {
        if (_shapeChanger.GetBlendShapeWeight(2) >= 100f)
            return;

        float newSize = _currentSize + _scalingAmount;

        _fighter.StartCoroutine(SmoothGrow(_currentSize, newSize));
    }

    private IEnumerator SmoothGrow(float currentSize, float targetSize)
    {
        while (currentSize <= targetSize)
        {
            currentSize += _scalingSpeed * Time.deltaTime;
            _shapeChanger.SetBlendShapeWeight(2, currentSize);
            yield return null;
        }

        yield return true;
    }

    private void Decrease()
    {
        if (_shapeChanger.GetBlendShapeWeight(2) <= 0f)
            return;

        float newSize = _currentSize - _scalingAmount;

        _fighter.StartCoroutine(SmoothDecrease(_currentSize, newSize));
    }

    private IEnumerator SmoothDecrease(float currentSize, float targetSize)
    {
        while (currentSize >= targetSize)
        {
            currentSize -= _scalingSpeed * Time.deltaTime;
            _shapeChanger.SetBlendShapeWeight(2, currentSize);
            yield return null;
        }

        yield return true;
    }
}
