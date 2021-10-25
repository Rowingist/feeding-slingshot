using System.Collections;
using UnityEngine;

public abstract class Food : MonoBehaviour
{
    private PlayerInput _playerInput;
    private FoodMover _foodMover;
    private Path _leftPath, _rightPath;
    private Collider _collider;
    private float _mooveSpeed;

    private void Awake()
    {
        _playerInput = GetComponentInParent<PlayerInput>();
        _foodMover = GetComponent<FoodMover>();
        _collider = GetComponent<Collider>();
        _mooveSpeed = 3f;
    }

    private void OnEnable()
    {
        _playerInput.ScreenSideChosen += OnSetPathSide;
        _playerInput.TouchPerformed += OnEnableMove;
    }

    private void Update()
    {
        Vector3 newPosition = _leftPath.GetStartPoint();
        float smoothSpeed = _mooveSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, newPosition, smoothSpeed);
    }

    private void OnDisable()
    {
        _playerInput.ScreenSideChosen -= OnSetPathSide;
        _playerInput.TouchPerformed -= OnEnableMove;
    }

    private void OnEnableMove()
    {
        _collider.enabled = true;
        _foodMover.enabled = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out StartEatingArea startEatingArea))
        {
            _collider.enabled = false;
            StartCoroutine(DeactiwateFood(0.33f));
        }
    }

    private void OnSetPathSide(Vector2 detouchViewPortPosition)
    {
        if (detouchViewPortPosition.x > 0.5f && detouchViewPortPosition.y < 0.75f)
            _foodMover.IntitPath(_rightPath);
        else if (detouchViewPortPosition.y < 0.75f)
            _foodMover.IntitPath(_leftPath);
    }

    public void InitPossiblePaths(Path leftPath, Path rightPath)
    {
        _leftPath = leftPath;
        _rightPath = rightPath;
    }

    private IEnumerator DeactiwateFood(float delay)
    {
        yield return new WaitForSeconds(delay);
        _foodMover.enabled = false;
        gameObject.SetActive(false);
    }
}