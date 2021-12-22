using System.Collections;
using UnityEngine;

public class FighterEatingState : FighterBaseState
{
    private Animator _animator;
    private int _eatTriggerHash;

    public FighterEatingState(Fighter fighter, IStationStateSwitcher stateSwitcher,
        Animator animator)
        : base(fighter, stateSwitcher)
    {
        _animator = animator;
        _eatTriggerHash = Animator.StringToHash("Eat");
    }

    public override void Start()
    {
        Eat();
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
        _animator.SetTrigger(_eatTriggerHash);
        _stateSwitcher.SwitchState<FighterSizeChangingState>();
    }

    public override void ChangeSize()
    {
    }

    public override void Win()
    {
    }

    public override void Lose()
    {
    }
}
