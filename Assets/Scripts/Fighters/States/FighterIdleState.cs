using UnityEngine;

public class FighterIdleState : FighterBaseState
{
    private Animator _animator;
    private StartButton _startButton;
    private int _idleAnimationHash;

    public FighterIdleState(Fighter fighter,  IStationStateSwitcher stateSwitcher, Animator animator, StartButton startButton)
        : base(fighter, stateSwitcher)
    {
        _animator = animator;
        _startButton = startButton;
        _idleAnimationHash = Animator.StringToHash("Idle");
    }

    public override void Start()
    {
        _startButton.Pushed += OnStartMove;
    }

    public override void Stop()
    {
        _startButton.Pushed -= OnStartMove;
    }

    public override void Idle()
    {
        Start();
        _animator.Play(_idleAnimationHash);
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

    private void OnStartMove()
    {
        _stateSwitcher.SwitchState<FighterRunState>();
    }
}
