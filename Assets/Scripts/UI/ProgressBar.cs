using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class ProgressBar : MonoBehaviour
{
    [SerializeField] private SizeChanger _playerSizeChanger;
    [SerializeField] private SizeChanger _enemySizeChanger;

    private Slider _slider;
    private float _startValue = 0.5f;

    private void Awake()
    {
        _slider = GetComponent<Slider>();
        _slider.value = _startValue;
    }

    private void OnEnable()
    {
    }

    private void OnDisable()
    {

    }

    private void OnIncreaceValue()
    {
    }

    private void OnDecreaceValue()
    {
        _slider.value -= 0.05f;
    }
}