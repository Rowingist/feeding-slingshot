using System.Collections;
using UnityEngine;

[RequireComponent(typeof(FighterSmoothMover))]
public class MoverSwitch : MonoBehaviour
{
    [SerializeField] private CountdownTimer _countdownTimer;
    [SerializeField] private GamePointsCounter _pointsCounter;
    [SerializeField] private Fighter _player;
    [SerializeField] private Fighter _enemy;

    private FighterSmoothMover _smoothMover;

    private void Awake()
    {
        _smoothMover = GetComponent<FighterSmoothMover>();
    }

    private void OnEnable()
    {
        _countdownTimer.GameStarted += OnDeactivateWithDelay;
        _pointsCounter.GameWasWon += OnDeactivate;
        _pointsCounter.GameWasLost += OnDeactivate;
        _player.Lost += OnDeactivate;
        _player.Won += OnDeactivate;
        _enemy.Won += OnDeactivate;
        _enemy.Lost += OnDeactivate;
    }

    private void OnDisable()
    {
        _countdownTimer.GameStarted -= OnDeactivateWithDelay;
        _pointsCounter.GameWasWon -= OnDeactivate;
        _pointsCounter.GameWasLost -= OnDeactivate;
        _player.Lost -= OnDeactivate;
        _player.Won -= OnDeactivate;
        _enemy.Won -= OnDeactivate;
        _enemy.Lost -= OnDeactivate;
    }

    private void OnDeactivateWithDelay()
    {
        StartCoroutine(SetActivationDelay());
    }

    private IEnumerator SetActivationDelay()
    {
        _smoothMover.enabled = false;

        yield return new WaitForSeconds(1f);

        _smoothMover.enabled = true;
    }

    private void OnDeactivate()
    {
        _smoothMover.enabled = false;
    }
}