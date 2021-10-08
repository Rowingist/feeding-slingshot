using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class FighterPushingState : FighterBaseState
{
    private Animator _animator;
    private int _pushIdleTriggerHash, _pushingBoolHash;
    private Fighter _opponent;
    private Game _game;

    public FighterPushingState(Fighter fighter, Text statusText, IStationStateSwitcher stateSwitcher,
        Animator animator, Fighter opponent, Game game)
    : base(fighter, statusText, stateSwitcher)
    {
        _animator = animator;
        _pushIdleTriggerHash = Animator.StringToHash("PushIdle");
        _pushingBoolHash = Animator.StringToHash("Push");
        _opponent = opponent;
        _game = game;
    }

    public override void Decreace()
    {
        _statusText.text = "Is not decreacing";
    }

    public override void Grow()
    {
        _statusText.text = "Is not growing";
    }

    public override void Idle()
    {
        _animator.SetTrigger(_pushIdleTriggerHash);
    }

    public override void Push()
    {
        float stepForwardDistanceX = _fighter.transform.position.x + _game.FighterStepSize;
        Vector3 stepForwardPosition = new Vector3(stepForwardDistanceX, _fighter.transform.position.y, _fighter.transform.position.z);
        _fighter.transform.DOMove(stepForwardPosition, 1.13f);
    }

    private void OnPush()
    {
        _fighter.StartCoroutine(SetPushAnimationDelay(1.13f));
    }

    public override void Run()
    {
        _statusText.text = "Is not running";
    }

    public override void Start()
    {
        _game.SteppedRight += OnPush;
        _game.SteppedLeft += OnMoveBackwards;
        _fighter.EatenFreshFood += OnPushAnimation;
        _opponent.EatenSpoiledFood += OnPushAnimation;
        _fighter.Won += OverGame;
        _opponent.Won += OnLoseState;
        _fighter.Lost += OnLoseState;
        _opponent.Lost += OverGame;
        Idle();
    }

    public override void Stop()
    {
        _game.SteppedRight -= OnPush;
        _game.SteppedLeft -= OnMoveBackwards;
        _fighter.EatenFreshFood -= OnPushAnimation;
        _opponent.EatenSpoiledFood -= OnPushAnimation;
        _fighter.Won -= OverGame;
        _opponent.Won -= OnLoseState;
        _fighter.Lost -= OnLoseState;
        _opponent.Lost -= OverGame;
    }

    public override void OverGame()
    {
            _stateSwitcher.SwitchState<FighterVictoryState>();
    }

    private void OnLoseState()
    {
            _stateSwitcher.SwitchState<FighterLoseState>();
    }

    private void OnMoveBackwards()
    {
        float stepBackwardDistanceX = _fighter.transform.position.x - _game.FighterStepSize;
        Vector3 stepBackwardPosition = new Vector3(stepBackwardDistanceX, _fighter.transform.position.y, _fighter.transform.position.z);
        _fighter.transform.DOMove(stepBackwardPosition, 1.13f);
    }

    private void OnPushAnimation()
    {
        _animator.SetTrigger(_pushingBoolHash);
    }

    private IEnumerator SetPushAnimationDelay(float delay)
    {
        Push();
        yield return new WaitForSeconds(delay);
        Idle();
    }
}
