using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class FighterStateMachine : MonoBehaviour, IStationStateSwitcher
{
    [SerializeField] private Fighter _fighter;
    [SerializeField] private Text _statusText;
    [SerializeField] private Animator _animator;
    [SerializeField] private StartButton _startButton;
    [SerializeField] private PushingArea _pushingArea;
    [SerializeField] private Transform _killingZone;
    [SerializeField] private Game _game;
    [SerializeField] private Fighter _opponent;

    private FighterBaseState _currentState;
    private List<FighterBaseState> _allStates;

    private void Start()
    {
        _allStates = new List<FighterBaseState>
        {
            new FighterIdleState(_fighter, _statusText, this, _animator, _startButton),
            new FighterRunState(_fighter, _statusText, this, _animator, _pushingArea),
            new FighterPushingState(_fighter, _statusText, this, _animator, _opponent, _game),
            new FighterGrowingState(_fighter, _statusText, this),
            new FighterDecreaseState(_fighter, _statusText, this),
            new FighterVictoryState(_fighter, _statusText, this, _animator),
            new FighterLoseState(_fighter, _statusText, this, _animator),
        };
        _currentState = _allStates[0];
        _currentState.Start();
    }

    public void Push()
    {
        _currentState.Push();
    }

    public void Grow()
    {
        _currentState.Grow();
    }

    public void Decreace()
    {
        _currentState.Decreace();
    }

    public void Win()
    {
        _currentState.OverGame();
    }

    public void Idle()
    {
        _currentState.Idle();
    }

    public void Run()
    {
        _currentState.Run();
    }

    public void SwitchState<T>() where T : FighterBaseState
    {
        var state = _allStates.FirstOrDefault(s => s is T);
        _currentState.Stop();
        state.Start();
        _currentState = state;
    }
}