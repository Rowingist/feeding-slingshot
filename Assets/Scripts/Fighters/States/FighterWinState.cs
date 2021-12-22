using UnityEngine;

public class FighterWinState : FighterBaseState
{
    private Animator _animator;
    private int _victoryTriggerHash;

    public FighterWinState(Fighter fighter,  IStationStateSwitcher stateSwitcher, 
        Animator animator)
        : base(fighter, stateSwitcher)
    {
        _animator = animator;
        _victoryTriggerHash = Animator.StringToHash("Win");
    }

    public override void Start()
    {
        _animator.SetTrigger(_victoryTriggerHash);
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