using UnityEngine;
using DG.Tweening;
using System.Collections;
using System;

public class FighterFastMover : MonoBehaviour
{
    [SerializeField] private FoodSpawner _foodSpawner;
    [SerializeField] private float _killingZonePositionX = 4.1f;

    private Vector3 _targetDirection;

    public event Action<float> KillingZoneReached;
    public event Action<int> Moved;

    private void OnEnable()
    {
        _foodSpawner.FoodActivated += OnMove;
    }

    private void OnDisable()
    {
        _foodSpawner.FoodActivated += OnMove;
    }

    private void Update()
    {
        if (transform.position.x >= _killingZonePositionX)
            KillingZoneReached?.Invoke(_killingZonePositionX);
        else if(transform.position.x <= -_killingZonePositionX)
            KillingZoneReached?.Invoke(_killingZonePositionX);
    }

    private void OnMove(int pathSide, bool foodIsSpoiled, float delayTime)
    {
        StartCoroutine(SetMoveDelay(pathSide, foodIsSpoiled, delayTime));
    }

    private IEnumerator SetMoveDelay(int pathSide, bool foodIsSpoiled, float delay)
    {
        yield return new WaitForSeconds(delay);

        switch (pathSide)
        {
            case -1:
                if (foodIsSpoiled)
                    Move(-1);
                else
                    Move(1);
                break;
            case 1:
                if (foodIsSpoiled)
                    Move(1);
                else
                    Move(-1);
                break;
        }
    }

    private void Move(int direction)
    {
        Moved?.Invoke(direction);
        _targetDirection = transform.position + new Vector3(direction, 0f, 0f);
        transform.DOMove(_targetDirection, 2f);
    }
}
