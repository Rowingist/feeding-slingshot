using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(Game))]
public class CameraFinishMove : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private Transform _lookingattarget;

    private Game _game;
    private Sequence _sequence;

    private void Awake()
    {
        _game = GetComponent<Game>();
        _sequence = DOTween.Sequence();
    }

    private void OnEnable()
    {
        _game.Over += OnStart;   
    }

    private void OnDisable()
    {
        _game.Over -= OnStart;
    }

    private void OnStart()
    {
        _sequence.Append(transform.DOMove(_target.position, 3));
        _sequence.Insert(0, transform.DOLookAt(_lookingattarget.position, 1));
    }

    public void SetTarget(Transform target)
    {
        _target = target;
    }
}
