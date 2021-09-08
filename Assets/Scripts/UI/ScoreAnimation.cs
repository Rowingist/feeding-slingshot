using UnityEngine;

[RequireComponent(typeof(Animator))]
public class ScoreAnimation : MonoBehaviour
{
    [SerializeField] private PlayerInput _playerInput;

    private Animator _animator;

    private string _moveOnLeft = "MoveScoreOnLeft";

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        _playerInput.Dragging += OnPlay;
    }

    private void OnDisable()
    {
        _playerInput.Dragging -= OnPlay;
    }

    private void OnPlay()
    {
        _animator.SetTrigger(_moveOnLeft);
    }
}