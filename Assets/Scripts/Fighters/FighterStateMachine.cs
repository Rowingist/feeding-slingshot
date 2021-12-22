using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(Fighter))]
public class FighterStateMachine : MonoBehaviour, IStationStateSwitcher
{
    [SerializeField] private Animator _animator;
    [SerializeField] private StartButton _startButton;
    [SerializeField] private Transform _pushingArea;
    [SerializeField] private GamePointsCounter _gamePointCounter;
    [SerializeField] private Transform _killingZone;
    [SerializeField] private SkinnedMeshRenderer _shapeChanger;
    [SerializeField, Range(1, 20)] private float _foodScalingFactor = 5f;
    [SerializeField] private float _runDuration = 2f;
    [SerializeField] private FighterFastMover _mover;
    [SerializeField] private Fighter _opponent;

    private Fighter _fighter;
    private FighterBaseState _currentState;
    private List<FighterBaseState> _allStates;

    private void Start()
    {
        _fighter = GetComponent<Fighter>();

        _allStates = new List<FighterBaseState>
        {
            new FighterIdleState(_fighter, this, _animator, _startButton),
            new FighterRunState(_fighter, this, _animator, _pushingArea, _runDuration),
            new FighterPushingIdleState(_fighter, this, _animator, _gamePointCounter, _mover, _opponent),
            new FighterEatingState(_fighter, this, _animator),
            new FighterSizeChangingState(_fighter, this, _animator, _foodScalingFactor, _shapeChanger),
            new FighterWinState(_fighter, this, _animator),
            new FighterLoseState(_fighter, this, _animator),
        };

        _currentState = _allStates[0];
        Idle();
    }

    public void Idle()
    {
        _currentState.Idle();
    }

    public void SwitchState<T>() where T : FighterBaseState
    {
        var state = _allStates.FirstOrDefault(s => s is T);
        _currentState.Stop();
        state.Start();
        _currentState = state;
    }
}