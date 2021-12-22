using System.Collections;
using UnityEngine;

public class ArrowsAnimationSwitcher : MonoBehaviour
{
    [SerializeField] private FighterFastMover _fighterFastMover;
    [SerializeField] private Animator _playerArrowsAnimator;
    [SerializeField] private Animator _enemyArrowsAnimator;
    [SerializeField] private CountdownTimer _countdownTimer;

    private int _moveFloatHash;

    private void Awake()
    {
        _moveFloatHash = Animator.StringToHash("Blend");
    }

    private void OnEnable()
    {
        _fighterFastMover.Moved += OnPlayMoveAnimation;
        _countdownTimer.GameStarted += OnStartEnemyArrowsSmoothMove;
    }

    private void OnDisable()
    {
        _fighterFastMover.Moved += OnPlayMoveAnimation;
        _countdownTimer.GameStarted -= OnStartEnemyArrowsSmoothMove;
    }

    private void OnPlayMoveAnimation(int direction)
    {
        if(direction == 1)
            StartCoroutine(SetAnimationDelay(_playerArrowsAnimator));
        else if (direction == -1)
            StartCoroutine(SetAnimationDelay(_enemyArrowsAnimator));
    } 

    private void OnStartEnemyArrowsSmoothMove()
    {
        StartCoroutine(SetStartDelay());
    }

    private IEnumerator SetAnimationDelay(Animator animator)
    {
        animator.SetFloat(_moveFloatHash, 1);

        yield return new WaitForSeconds(1f);

        animator.SetFloat(_moveFloatHash, 0.5f);
    }

    private IEnumerator SetStartDelay()
    {
        yield return new WaitForSeconds(1f);
        _enemyArrowsAnimator.SetFloat(_moveFloatHash, 0.5f);
    }
}