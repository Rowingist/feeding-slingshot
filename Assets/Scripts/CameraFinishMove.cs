using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(Game))]
public class CameraFinishMove : MonoBehaviour
{
    [SerializeField] private Transform _target;

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
        _game.Won += OnStart;   
    }

    private void OnDisable()
    {
        _game.Over -= OnStart;
        _game.Won -= OnStart;
    }

    private void OnStart()
    {
        _sequence.Append(transform.DOMove(_target.position, 3));
        _sequence.Insert(0, transform.DORotate(new Vector3(13, -_target.position.x, 0), 3));
    }

    public void SetTarget(Transform target)
    {
        _target = target;
    }
}
