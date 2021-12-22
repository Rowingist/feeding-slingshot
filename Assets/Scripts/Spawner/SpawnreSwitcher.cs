using System.Collections;
using UnityEngine;

[RequireComponent(typeof(GamePointsCounter))]
public class SpawnreSwitcher : MonoBehaviour
{
    [SerializeField] private CountdownTimer _startTimer;
    [SerializeField] private FoodSpawner _foodSpawner;
    
    private GamePointsCounter _pointsCounter;

    private void Awake()
    {
        _pointsCounter = GetComponent<GamePointsCounter>();
    }

    private void OnEnable()
    {
        _startTimer.GameStarted += OnSwitch;
        _pointsCounter.GameWasWon += OnDeactivate;
        _pointsCounter.GameWasLost += OnDeactivate;
    }

    private void OnDisable()
    {
        _startTimer.GameStarted -= OnSwitch;
        _pointsCounter.GameWasWon += OnDeactivate;
        _pointsCounter.GameWasLost += OnDeactivate;
    }

    private void OnSwitch()
    {
        _foodSpawner.gameObject.SetActive(true);
    }

    private void OnDeactivate()
    {
        StartCoroutine(SetDeactiwationDelay(1f));
    }

    private IEnumerator SetDeactiwationDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        _foodSpawner.gameObject.SetActive(false);
    }
}