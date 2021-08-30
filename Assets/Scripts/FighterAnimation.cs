using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Animator), typeof(Rigidbody), typeof(BoxCollider))]
public class FighterAnimation : MonoBehaviour
{
    [SerializeField] private Fighter _enemy;

    private Fighter _fighter;
    private Animator _animator;
    private Rigidbody _rigidbody;
    private BoxCollider _boxCollider;
    private string _gameOverState = "FallDown", _victoryState = "Victory";

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _fighter = GetComponent<Fighter>();
        _rigidbody = GetComponent<Rigidbody>();
        _boxCollider = GetComponent<BoxCollider>();
    }

    private void OnEnable()
    {
        _enemy.Killed += OnVictoryState;
        _fighter.Killed += OnLooseState;
    }

    private void OnDisable()
    {
        _enemy.Killed -= OnVictoryState;
        _fighter.Killed += OnLooseState;
    }

    public void OnLooseState()
    {
        _animator.Play(_gameOverState);
        _rigidbody.useGravity = true;
        _boxCollider.isTrigger = false;
        StartCoroutine(SetDeletionDelay(2f));
    }

    private void OnVictoryState()
    {
        _animator.Play(_victoryState);
    }

    private IEnumerator SetDeletionDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        Destroy(gameObject);
    }
}
