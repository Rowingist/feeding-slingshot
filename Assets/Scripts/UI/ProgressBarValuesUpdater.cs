using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

[RequireComponent(typeof(Slider))]
public class ProgressBarValuesUpdater : MonoBehaviour
{
    [SerializeField] private GamePointsCounter _game;
    [SerializeField] private bool _isInverted;
    [SerializeField] private StartButton _startButton;

    private Slider _slider;

    private void Awake()
    {
        _slider = GetComponent<Slider>();
    }

    private void OnEnable()
    {
        _startButton.Pushed += OnStart;
        _game.PointsIncreased += OnUpdateValue;
        _game.PointsDecreased += OnUpdateValue;
    }

    private void OnDisable()
    {
        _startButton.Pushed -= OnStart;
        _game.PointsIncreased -= OnUpdateValue;
        _game.PointsDecreased -= OnUpdateValue;
    }

    private void OnStart()
    {
        int startPoints = _game.CurrentPoints;
        _slider.maxValue = _game.PointsQuantityToWin;
        _slider.DOValue(startPoints, 1f);
    }

    private void OnUpdateValue()
    {
        float currentPoints;

        if (_isInverted)
        {
            currentPoints = _slider.maxValue - _game.CurrentPoints;
        }
        else
        {
            currentPoints = _game.CurrentPoints;
        }

        _slider.DOValue(currentPoints, 1f); 
    }
}