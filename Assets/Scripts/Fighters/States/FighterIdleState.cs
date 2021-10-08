using UnityEngine;
using UnityEngine.UI;

public class FighterIdleState : FighterBaseState
{
    private Animator _animator;
    private StartButton _startButton;
    private int _idleAnimationHash;

    public FighterIdleState(Fighter fighter, Text statusText, IStationStateSwitcher stateSwitcher, Animator animator, StartButton startButton)
        : base(fighter, statusText, stateSwitcher)
    {
        _animator = animator;
        _startButton = startButton;
        _idleAnimationHash = Animator.StringToHash("Idle");
    }

    public override void Decreace()
    {
        _statusText.text = "Is waiting for start.";
    }

    public override void Grow()
    {
        _statusText.text = "Is waiting for start.";
    }

    public override void Idle()
    {
        _animator.Play(_idleAnimationHash);
    }

    public override void Push()
    {
        _statusText.text = "Is waiting for start.";
    }

    public override void Run()
    {
        _statusText.text = "Is waiting for start.";
    }

    public override void Start()
    {
        _startButton.GameStarted += OnStartMove;
        Idle();
    }

    private void OnStartMove()
    {
        _stateSwitcher.SwitchState<FighterRunState>();
    }

    public override void Stop()
    {
        _startButton.GameStarted -= OnStartMove;
    }

    public override void OverGame()
    {
        _statusText.text = "Is waiting for start.";
    }
}
