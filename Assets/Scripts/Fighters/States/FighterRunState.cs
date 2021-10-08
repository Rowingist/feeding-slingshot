using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class FighterRunState : FighterBaseState
{   
    private Animator _animator;
    private PushingArea _pushingArea;
    private int _runTriggerHash;

    public FighterRunState(Fighter fighter, Text statusText, IStationStateSwitcher stateSwitcher, Animator animator, PushingArea pushingArea)
        : base(fighter, statusText, stateSwitcher)
    {
        _animator = animator;
        _pushingArea = pushingArea;
        _runTriggerHash = Animator.StringToHash("Run");
    }

    public override void Decreace()
    {
        _statusText.text = "Is not decreasing";
    }

    public override void Grow()
    {
        _statusText.text = "Is not growing";
    }

    public override void Idle()
    {
        _statusText.text = "Is not staying";
    }

    public override void Push()
    {
        _statusText.text = "Is not pushing";
    }

    public override void Run()
    {
        _animator.SetTrigger(_runTriggerHash);
        _fighter.transform.DOMove(_pushingArea.transform.position, 1f).SetEase(0);
    }

    public override void Start()
    {
        _fighter.StartedPush += OnStartPush;
        Run();
    }

    private void OnStartPush()
    {
        _stateSwitcher.SwitchState<FighterPushingState>();
    }

    public override void Stop()
    {
        _fighter.StartedPush -= OnStartPush;
    }

    public override void OverGame()
    {
        _statusText.text = "Did not win";
    }
}
