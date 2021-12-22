using System;
using System.Collections;
using UnityEngine;

public class Fighter : MonoBehaviour
{
    [SerializeField] private FoodSpawner _foodSpawner;
    [SerializeField] private GamePointsCounter _pointsCounter;
    [SerializeField] private PushingStartArea _pushingStartArea;
    [SerializeField] private FighterFastMover _fighterFastMover;
    [SerializeField, Range(-1, 1)] private int _pathSide;

    private float _periodOfAction;

    public event Action EatenFreshFood;
    public event Action EatenSpoiledFood;
    public event Action StartedPush;
    public event Action Won;
    public event Action Lost;

    public int PlayPoints { get; private set; }
    public int EatenFoodQuality { get; private set; }

    private void OnEnable()
    {
        _foodSpawner.FoodActivated += OnEat;
        _fighterFastMover.KillingZoneReached += OnSetGameOverState;
    }

    private void OnDisable()
    {
        _foodSpawner.FoodActivated -= OnEat;
        _fighterFastMover.KillingZoneReached -= OnSetGameOverState;
    }

    private void OnEat(int pathSide, bool foodIsSpoiled, float delay)
    {
        StartCoroutine(SetMoveDelay(pathSide, foodIsSpoiled, delay));
    }

    private IEnumerator SetMoveDelay(int pathSide, bool foodIsSpoiled, float delay)
    {
        yield return new WaitForSeconds(delay + 0.1f);

        switch (foodIsSpoiled)
        {
            case false:
                EatFreshFood(pathSide);
                EatenFoodQuality = 1;
                break;
            case true:
                EatSpoiledFood(pathSide);
                EatenFoodQuality = 0;
                break;
        }
    }

    private void Update()
    {
        if (Vector3.Distance(transform.position, _pushingStartArea.transform.position) <= 2f)
            StartedPush?.Invoke();
    }

    private void EatFreshFood(int pahtSide)
    {
        if (_pathSide == pahtSide)
        {
            PlayPoints += 10;
            EatenFreshFood?.Invoke();
        }
    }

    private void EatSpoiledFood(int pahtSide)
    {
        if (_pathSide == pahtSide)
        {
            if (PlayPoints >= 5)
                PlayPoints -= 5;

            EatenSpoiledFood?.Invoke();
        }
    }

    private void OnSetGameOverState(float position)
    {
        if (position < 0 && _pathSide < 0)
            SetLoseStae();
        else if (position < 0 && _pathSide > 0)
            SetWinState();
        else if (position > 0 && _pathSide < 0)
            SetLoseStae();
        else if (position > 0 && _pathSide > 0)
            SetWinState();
    }

    public void SetWinState()
    {
        Won?.Invoke();
    }

    public void SetLoseStae()
    {
        Lost?.Invoke();
    }

    private void OnFillTheGaps(float deltaActivationTime)
    {
        _periodOfAction = deltaActivationTime;
    }
}