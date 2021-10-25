using UnityEngine;

public class FighterPushingIdleState : FighterBaseState
{
    private Animator _animator;
    private int _pushIdleTriggerHash;
    private float _fighterStepSize;
    private GamePointsCounter _pointsCounter;
    private FighterFastMover _mover;

    public FighterPushingIdleState(Fighter fighter, IStationStateSwitcher stateSwitcher,
        Animator animator, GamePointsCounter pointsCounter, FighterFastMover mover) : base(fighter, stateSwitcher)
    {
        _animator = animator;
        _pushIdleTriggerHash = Animator.StringToHash("PushIdle");
        _pointsCounter = pointsCounter;
        _fighterStepSize = 1.6f;
        _mover = mover;
    }

    public override void Start()
    {
        _animator.SetTrigger(_pushIdleTriggerHash);

        _fighter.EatenFreshFood += Eat;
        _fighter.EatenSpoiledFood += Eat;

        _pointsCounter.PointsIncreased += PushForward;
        _pointsCounter.PointsDecreased += StepBackwards;

        _fighter.Won += Win;
        _fighter.Lost += Lose;
    }

    public override void Stop()
    {
        _fighter.EatenFreshFood -= Eat;
        _fighter.EatenSpoiledFood -= Eat;

        _pointsCounter.PointsIncreased -= PushForward;
        _pointsCounter.PointsDecreased -= StepBackwards;

        _fighter.Won -= Win;
        _fighter.Lost -= Lose;
    }

    public override void Idle()
    {

    }

    public override void Run()
    {
    }

    public override void StepBackwards()
    {
        Move(-_fighterStepSize, 3f);
    }

    public override void Eat()
    {
        _stateSwitcher.SwitchState<FighterEatingState>();
    }

    public override void ChangeSize()
    {
    }

    public override void PushForward()
    {
        Move(_fighterStepSize, 3f);
    }

    public override void Win()
    {
        _stateSwitcher.SwitchState<FighterWinState>();
    }

    public override void Lose()
    {
        _stateSwitcher.SwitchState<FighterLoseState>();
    }

    private void Move(float fighterStepSize, float mooveSpeed)
    {
        Vector3 currentPosition = _fighter.transform.position;
        Vector3 newPosition = currentPosition + new Vector3(fighterStepSize, 0f, 0f);
        _mover.enabled = true;
        _mover.SetParameters(newPosition, mooveSpeed);
    }
}