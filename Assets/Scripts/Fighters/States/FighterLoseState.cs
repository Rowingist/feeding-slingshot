using UnityEngine;

public class FighterLoseState : FighterBaseState
{
    private Animator _animator;
    private int _loseTriggerHash;

    public FighterLoseState(Fighter fighter, IStationStateSwitcher stateSwitcher, 
        Animator animator)
        : base(fighter, stateSwitcher)
    {
        _animator = animator;
        _loseTriggerHash = Animator.StringToHash("Lose");
    }

    public override void Start()
    {
        _animator.SetTrigger(_loseTriggerHash);
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
    }

    public override void Win()
    {
    }

    public override void Lose()
    {
    }
}