using UnityEngine;

public abstract class Food : MonoBehaviour
{
    private PlayerInput _playerInput;
    private FoodMover _foodMover;
    private Transform[] _playerPathPoints;
    private Transform[] _enemyPathPoints;

    private void Awake()
    {
        _playerInput = GetComponentInParent<PlayerInput>();
        _foodMover = GetComponent<FoodMover>();
    }

    private void OnEnable()
    {
        _playerInput.ScreenSideChosen += OnSetPathSide;
        _playerInput.TouchPerformed += OnEnableMove;
    }

    private void OnDisable()
    {
        _playerInput.ScreenSideChosen -= OnSetPathSide;
        _playerInput.TouchPerformed -= OnEnableMove;
    }

    private void OnEnableMove()
    {
        _foodMover.enabled = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.TryGetComponent(out Food food))
        {
            _foodMover.enabled = false;
            gameObject.SetActive(false);
        }
    }

    private void OnSetPathSide(Vector2 detouchViewPortPosition)
    {
        if (detouchViewPortPosition.x > 0.5f && detouchViewPortPosition.y < 0.75f)
            _foodMover.IntitParabolaRoots(_enemyPathPoints);
        else if (detouchViewPortPosition.y < 0.75f)
            _foodMover.IntitParabolaRoots(_playerPathPoints);
    }

    public void InitPossiblePathPoints(Transform[] playerPathPoints, Transform[] enemyPathPoints)
    {
        _playerPathPoints = playerPathPoints;
        _enemyPathPoints = enemyPathPoints;
    }
}