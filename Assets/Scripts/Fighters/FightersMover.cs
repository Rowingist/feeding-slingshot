using UnityEngine;

public class FightersMover : MonoBehaviour
{
    [SerializeField] private FighterSizeChanger _playerFighter;
    [SerializeField] private FighterSizeChanger _enemyFighter;
    [SerializeField] private Game _game;
    [SerializeField, Range(0f, 2f)] private float _speed = 0.2f;

    public float XShift { get; private set; }

    private void OnEnable()
    {
        _game.Won += OnDeactivate;
        _game.Over += OnDeactivate;
    }

    private void OnDisable()
    {
        _game.Won -= OnDeactivate;
        _game.Over -= OnDeactivate;
    }

    private void Update()
    {
        SetMoveDistance();
        Move();
    }

    private void SetMoveDistance()
    {
        XShift = _playerFighter.CurrentSkinSize - _enemyFighter.CurrentSkinSize;
    }

    private void Move()
    {
        Vector3 newPosition = new Vector3(XShift / 100, transform.localPosition.y, transform.localPosition.z);
        transform.localPosition = Vector3.MoveTowards(transform.localPosition, newPosition, _speed * Time.deltaTime);
    }

    private void OnDeactivate()
    {
        enabled = false;
    }
}