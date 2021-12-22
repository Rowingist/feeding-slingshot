using System.Collections;
using UnityEngine;
using DG.Tweening;

public class FighterSizeChangingState : FighterBaseState
{
    private Animator _animator;
    private SkinnedMeshRenderer _shapeChanger;

    private float _scalingStep, _currentSize;
    private int _floatGettingFatHash, _pushTriggerHash, _stopPushingTriggerHash;

    public FighterSizeChangingState(Fighter fighter, IStationStateSwitcher stateSwitcher, 
        Animator animator, float scalingStep, SkinnedMeshRenderer shapeChanger) : base(fighter, stateSwitcher)
    {
        _animator = animator;
        _scalingStep = scalingStep;
        _shapeChanger = shapeChanger;
        _floatGettingFatHash = Animator.StringToHash("GettingFat");
        _pushTriggerHash = Animator.StringToHash("Push");
        _stopPushingTriggerHash = Animator.StringToHash("StopPush");
    }

    public override void Start()
    {
        ChangeSize();
    }

    public override void Stop()
    {
        
    }

    public override void Idle()
    {

    }

    public override void Run()
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

        _stateSwitcher.SwitchState<FighterPushingIdleState>();
    }

    public override void Win()
    {
    }

    public override void Lose()
    {
    }

    private void Increase()
    {
        if (_shapeChanger.GetBlendShapeWeight(2) >=  100f)
            return;

        _fighter.StartCoroutine(SmoothGrow());
    }

    private IEnumerator SmoothGrow()
    {
        float newSize = (_shapeChanger.GetBlendShapeWeight(2) + _scalingStep) / 100;

        while (_shapeChanger.GetBlendShapeWeight(2) / 100 <= newSize)
        {
            _currentSize = (_shapeChanger.GetBlendShapeWeight(2) / 100) + 0.005f;
            _animator.SetFloat(_floatGettingFatHash, _currentSize);
            yield return null;
        }

        yield return true;
    }

    private void Decrease()
    {
        if (_shapeChanger.GetBlendShapeWeight(2) <= 0f)
            return;

        _fighter.StartCoroutine(SmoothDecrease());
    }

    private IEnumerator SmoothDecrease()
    {
        float newSize = (_shapeChanger.GetBlendShapeWeight(2) - _scalingStep) / 100;

        while (_shapeChanger.GetBlendShapeWeight(2) / 100 >= newSize)
        {
            _currentSize = (_shapeChanger.GetBlendShapeWeight(2) / 100) - 0.005f;
            _animator.SetFloat(_floatGettingFatHash, _currentSize);
            yield return null;
        }

        yield return true;
    }
}
