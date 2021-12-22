using UnityEngine;
using DG.Tweening;

public class FighterPushingIdleState : FighterBaseState
{
    private Animator _animator;
    private int _pushIdleTriggerHash;

    public FighterPushingIdleState(Fighter fighter, IStationStateSwitcher stateSwitcher,
        Animator animator, GamePointsCounter pointsCounter, FighterFastMover mover, Fighter opponent) : base(fighter, stateSwitcher)
    {
        _animator = animator;
        _pushIdleTriggerHash = Animator.StringToHash("PushIdle");
    }

    public override void Start()
    {
        _animator.SetTrigger(_pushIdleTriggerHash);

        _fighter.EatenFreshFood += Eat;
        _fighter.EatenSpoiledFood += Eat;

        _fighter.Won += Win;
        _fighter.Lost += Lose;
    }

    public override void Stop()
    {
        _fighter.EatenFreshFood -= Eat;
        _fighter.EatenSpoiledFood -= Eat;

        _fighter.Won -= Win;
        _fighter.Lost -= Lose;
    }

    public override void Idle() {}

    public override void Run() {}

    public override void Eat()
    {
        _stateSwitcher.SwitchState<FighterEatingState>();
    }

    public override void ChangeSize() {}

    public override void Win()
    {
        _stateSwitcher.SwitchState<FighterWinState>();
    }

    public override void Lose()
    {
        _stateSwitcher.SwitchState<FighterLoseState>();
    }
}