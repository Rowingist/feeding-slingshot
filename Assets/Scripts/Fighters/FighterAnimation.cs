using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Animator), typeof(BoxCollider), typeof(Rigidbody))]
[RequireComponent(typeof(FighterSizeChanger))]
public class FighterAnimation : MonoBehaviour
{
    [SerializeField] private FighterSizeChanger _enemy;

    private Animator _animator;
    private BoxCollider _boxCollider;
    private Rigidbody _rigidbody;
    private FighterSizeChanger _fighterSizeChanger;

    private string _gameOverState = "FallDown", _victoryState = "Victory";

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _boxCollider = GetComponent<BoxCollider>();
        _rigidbody = GetComponent<Rigidbody>();
        _fighterSizeChanger = GetComponent<FighterSizeChanger>();
    }

    private void OnEnable()
    {
        _fighterSizeChanger.Lost += OnLooseState;
        _enemy.Lost += OnVictoryState;
    }

    private void OnDisable()
    {
        _fighterSizeChanger.Lost -= OnLooseState;
        _enemy.Lost -= OnVictoryState;
    }

    public void OnLooseState()
    {
        _animator.Play(_gameOverState);
        _rigidbody.useGravity = true;
        StartCoroutine(SetDeletionDelay(5f));
    }

    private IEnumerator SetDeletionDelay(float delay)
    {
        yield return new WaitForSeconds(0.25f);
        _boxCollider.isTrigger = false;
        yield return new WaitForSeconds(delay);
        gameObject.SetActive(false);
    }

    private void OnVictoryState()
    {
        _animator.Play(_victoryState);
    }
}