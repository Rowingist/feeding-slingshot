using System.Collections;
using UnityEngine;

public class FighterEatingState : FighterBaseState
{
    private Animator _animator;
    private int _pushTriggerHash, _stopPushTriggerHash;
    private SkinnedMeshRenderer _shapeChanger;
    private float _scalingSpeed = 400f;
    private float _currentMouthSize;

    public FighterEatingState(Fighter fighter, IStationStateSwitcher stateSwitcher,
        Animator animator, SkinnedMeshRenderer shapeChanger)
        : base(fighter, stateSwitcher)
    {
        _animator = animator;
        _pushTriggerHash = Animator.StringToHash("Push");
        _stopPushTriggerHash = Animator.StringToHash("StopPush");
        _shapeChanger = shapeChanger;
        _currentMouthSize = _shapeChanger.GetBlendShapeWeight(3);
    }

    public override void Start()
    {
        _animator.SetTrigger(_pushTriggerHash);
        Eat();
        _stateSwitcher.SwitchState<FighterSizeChangingState>();
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

    public override void StepBackwards()
    {
    }

    public override void Eat()
    {
        _fighter.StartCoroutine(OpenMouth(_currentMouthSize));
    }

    public override void ChangeSize()
    {
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

    private IEnumerator OpenMouth(float currentSize)
    {
        while (currentSize <= 100f)
        {
            currentSize += _scalingSpeed * Time.deltaTime;
            _shapeChanger.SetBlendShapeWeight(3, currentSize);
            yield return null;
        }

        yield return new WaitForSeconds(0.3f);

        _fighter.StartCoroutine(CloseMouth(currentSize));

        yield return true;
    }

    private IEnumerator CloseMouth(float currentSize)
    {
        while (currentSize > 0f)
        {
            currentSize -= _scalingSpeed * Time.deltaTime;
            _shapeChanger.SetBlendShapeWeight(3, currentSize);
            yield return null;
        }

        _animator.SetTrigger(_stopPushTriggerHash);

        yield return true;
    }
}
