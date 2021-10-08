using UnityEngine;
using UnityEngine.UI;

public class FighterLoseState : FighterBaseState
{
    private Animator _animator;
    private int _loseTriggerHash;

    public FighterLoseState(Fighter fighter, Text statusText, IStationStateSwitcher stateSwitcher, Animator animator)
        : base(fighter, statusText, stateSwitcher)
    {
        _animator = animator;
        _loseTriggerHash = Animator.StringToHash("Lose");
    }

    public override void Decreace()
    {
        _statusText.text = "Is not decreasing";
    }

    public override void Grow()
    {
        _statusText.text = "Is not growing";
    }

    public override void Push()
    {
        _statusText.text = "Is not pushing";
    }

    public override void Start()
    {
        OverGame();
    }

    public override void Stop()
    {

    }

    public override void OverGame()
    {
        _animator.SetTrigger(_loseTriggerHash);
    }

    public override void Idle()
    {
        _statusText.text = "Is not staying";
    }

    public override void Run()
    {
        _statusText.text = "Is not running";
    }
}