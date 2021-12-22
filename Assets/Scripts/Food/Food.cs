using System;
using System.Collections;
using UnityEngine;

public class Food : MonoBehaviour
{
    [SerializeField] private bool _isSpoiled;

    private PlayerInput _playerInput;
    private FoodMover _foodMover;
    private Path _leftPath, _rightPath;
    private float _followCameraSpeed, _activationTime;

    public bool IsSpoiled => _isSpoiled;
    public int PathSideIndex { get; private set; }
    public float ActivationTime => _activationTime;

    public event Action StartedToMove;

    private void Awake()
    {
        _playerInput = GetComponentInParent<PlayerInput>();
        _foodMover = GetComponent<FoodMover>();
        _followCameraSpeed = 3f;
    }

    private void OnEnable()
    {
        _foodMover.ApproachingToCharacter += OnDeactivate;
        _playerInput.ScreenSideChosen += OnSetPathSide;
        _playerInput.TouchPerformed += OnEnableMove;
    }

    private void Update()
    {
        Vector3 newPosition = _leftPath.GetStartPoint();
        float smoothSpeed = _followCameraSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, newPosition, smoothSpeed);
    }

    private void OnDisable()
    {
        _foodMover.ApproachingToCharacter += OnDeactivate;
        _playerInput.ScreenSideChosen -= OnSetPathSide;
        _playerInput.TouchPerformed -= OnEnableMove;
    }

    private void OnEnableMove()
    {
        StartedToMove?.Invoke();
        _foodMover.enabled = true;
    }

    public void InitPossiblePaths(Path leftPath, Path rightPath)
    {
        _leftPath = leftPath;
        _rightPath = rightPath;
    }

    public void SetActivationTime(float activationTime)
    {
        _activationTime = activationTime;
    }

    private void OnSetPathSide(Vector2 detouchViewPortPosition)
    {
        if (detouchViewPortPosition.x > 0.5f && detouchViewPortPosition.y < 0.75f)
        {
            _foodMover.IntitPath(_rightPath);
            PathSideIndex = 1;
        }
        else if (detouchViewPortPosition.y < 0.75f)
        {
            _foodMover.IntitPath(_leftPath);
            PathSideIndex = -1;
        }
    }

    private void OnDeactivate(float approachDistance)
    {
        StartCoroutine(SetDelayDeactivation(approachDistance));
    }

    private IEnumerator SetDelayDeactivation(float delay)
    {
        yield return new WaitForSeconds(delay);

        _foodMover.enabled = false;
        gameObject.SetActive(false);
    }
}