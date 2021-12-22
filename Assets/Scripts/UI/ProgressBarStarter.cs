using DG.Tweening;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBarStarter : MonoBehaviour
{
    [SerializeField] private bool _isInverted;
    [SerializeField] private StartButton _startButton;
    [SerializeField, Range(1f, 100f)] private float _killZonePositionX = 5.2f;

    private Slider _slider;
    private ProgressBarValuesUpdater _valuesUpdater;

    private void Awake()
    {
        _slider = GetComponent<Slider>();
        _valuesUpdater = GetComponent<ProgressBarValuesUpdater>();
    }

    private void OnEnable()
    {
        _startButton.Pushed += OnUpdateValue;
    }

    private void Start()
    {
        if (!_isInverted)
        {
            _slider.maxValue = _killZonePositionX;
            _slider.minValue = -_killZonePositionX;
        }

        _slider.value = _slider.minValue;
    }

    private void OnDisable()
    {
        _startButton.Pushed -= OnUpdateValue;
    }

    private void OnUpdateValue()
    {
        if (_isInverted)
        { 
            _slider.DOValue(1f, 2f); 
        }
        else
        {
            _slider.DOValue(0f, 0.7f);
            StartCoroutine(SetDelay(1f));
        }
    }

    private IEnumerator SetDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        _valuesUpdater.enabled = true;
    }
}
