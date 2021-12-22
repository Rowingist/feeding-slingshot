using UnityEngine;
using DG.Tweening;
using System.Collections;

public class FighterRunState : FighterBaseState
{   
    private Animator _animator;
    private Transform _pushingArea;
    private int _runTriggerHash;
    private float _runDuration;

    public FighterRunState(Fighter fighter, IStationStateSwitcher stateSwitcher, Animator animator, 
        Transform pushingArea, float runDuration)
        : base(fighter, stateSwitcher)
    {
        _animator = animator;
        _pushingArea = pushingArea;
        _runTriggerHash = Animator.StringToHash("Run");
        _runDuration = runDuration;
    }

    public override void Start()
    {
        Run();
        _fighter.StartedPush += OnStayInPushIdle;
    }

    public override void Stop()
    {
        _fighter.StartedPush -= OnStayInPushIdle;
    }

    public override void Idle()
    {
    }

    public override void Run()
    {
        _animator.SetTrigger(_runTriggerHash);
        _fighter.transform.DOMove(_pushingArea.transform.position, _runDuration);
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

    private void OnStayInPushIdle()
    {
        _fighter.StartCoroutine(StayInPush(0.2f));
    }

    private IEnumerator StayInPush(float delay)
    {
        yield return new WaitForSeconds(delay);
        _stateSwitcher.SwitchState<FighterPushingIdleState>();
    }
}