using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class ProgressBar : MonoBehaviour
{
    [SerializeField] private FighterSizeChanger _playerSizeChanger;
    [SerializeField] private FighterSizeChanger _enemySizeChanger;

    private Slider _slider;
    private float _startValue = 0.5f;

    private void Awake()
    {
        _slider = GetComponent<Slider>();
        _slider.value = _startValue;
    }

    private void OnEnable()
    {
        _playerSizeChanger.EatenFood += OnEncreaceValue;
        _enemySizeChanger.EatenFood += OnDecreaceValue;
    }

    private void OnDisable()
    {
        _playerSizeChanger.EatenFood += OnEncreaceValue;
        _enemySizeChanger.EatenFood += OnDecreaceValue;
    }

    private void OnEncreaceValue()
    {
        _slider.value += _startValue / _playerSizeChanger.ScaleFactor;
    }

    private void OnDecreaceValue()
    {
        _slider.value -= 0.05f;
    }
}