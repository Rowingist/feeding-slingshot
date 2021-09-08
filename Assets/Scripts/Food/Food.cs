using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(PlayerInput), typeof(FoodMover), typeof(PathChanger))]
[RequireComponent(typeof(PathRenderer))]
public class Food : MonoBehaviour
{
    private PlayerInput _mouseService;
    private FoodMover _foodMover;
    private PathChanger _pointerMover;
    private PathRenderer _pathRenderer;
    private Vector3 _slingshotRuberPosition;

    private void Awake()
    {
        _mouseService = GetComponent<PlayerInput>();
        _foodMover = GetComponent<FoodMover>();
        _pointerMover = GetComponent<PathChanger>();
        _pathRenderer = GetComponent<PathRenderer>();
    }

    private void OnEnable()
    {
        _mouseService.LeftButtonReleased += OnActivateFoodMover;
        transform.DOMove(_slingshotRuberPosition, 0.3f).SetEase(Ease.Linear).Restart(true);
    }

    private void OnDisable()
    {
        _mouseService.LeftButtonReleased -= OnActivateFoodMover;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out FighterSizeChanger fighter))
        {
            _foodMover.enabled = false;
            _pathRenderer.ResetLine();
            gameObject.SetActive(false);
        }

        if(other.TryGetComponent(out ForbidenArea forbidenArea))
        {
            _foodMover.enabled = false;
            gameObject.SetActive(false);
        }
    }

    private void OnActivateFoodMover()
    {
        _foodMover.enabled = true;
        _pointerMover.enabled = false;
    }

    public void InitSlingshotRuberPosition(Vector3 position)
    {
        _slingshotRuberPosition = position + new Vector3(0f, 0f, 0.01f);
    }
}