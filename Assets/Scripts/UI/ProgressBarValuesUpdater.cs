using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System.Collections;

[RequireComponent(typeof(Slider))]
public class ProgressBarValuesUpdater : MonoBehaviour
{
    [SerializeField] private FighterFastMover _fightersBox;

    private Slider _slider;

    private void Awake()
    {
        _slider = GetComponent<Slider>();
    }

    private void Update()
    {
        _slider.value = _fightersBox.transform.position.x;
    }
}