using UnityEngine;

public class ArrowsAnimationSwitcher : MonoBehaviour
{
    [SerializeField] private GamePointsCounter _game;
    [SerializeField] private Animator _playerArrowsAnimator;
    [SerializeField] private Animator _enemyArrowsAnimator;

    private int _moveTriggerHash;

    private void Awake()
    {
        _moveTriggerHash = Animator.StringToHash("Accelerate");
    }

    private void OnEnable()
    {
        _game.PointsIncreased += OnPlayerMoveAnimation;
        _game.PointsDecreased += OnEnemyMoveAnimation;
    }

    private void OnDisable()
    {
        _game.PointsIncreased -= OnPlayerMoveAnimation;
        _game.PointsDecreased -= OnEnemyMoveAnimation;
    }

    private void OnPlayerMoveAnimation()
    {
        _playerArrowsAnimator.SetTrigger(_moveTriggerHash);
    }

    private void OnEnemyMoveAnimation()
    {
        _enemyArrowsAnimator.SetTrigger(_moveTriggerHash);
    }
}