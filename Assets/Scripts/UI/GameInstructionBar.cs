using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

[RequireComponent(typeof(Slider))]
public class GameInstructionBar : MonoBehaviour
{
    private Slider _instructionSlider;

    private void Start()
    {
        _instructionSlider = GetComponent<Slider>();
        _instructionSlider.DOValue(_instructionSlider.maxValue, 1f).SetEase(Ease.Linear).SetLoops(-1, LoopType.Yoyo).SetDelay(0.4f);
    }
}