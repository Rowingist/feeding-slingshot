using Zenject;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class SlingshotAnimation : MonoBehaviour
{
    private Animator _amimator;
    private IMouseService _mouseService;

    private string _aiming = "Aim";
    private string _shoot = "Shoot";

    [Inject]
    private void Construct(IMouseService mouseService)
    {
        _mouseService = mouseService;
    }

    private void Awake()
    {
        _amimator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        _mouseService.LeftButtonPressed += OnAiming;
        _mouseService.LeftButtonReleased += OnShoot;
    }

    private void OnDisable()
    {
        _mouseService.LeftButtonPressed -= OnAiming;
        _mouseService.LeftButtonReleased -= OnShoot;

    }

    private void OnAiming()
    {
        _amimator.SetTrigger(_aiming);
    }

    private void OnShoot()
    {
        _amimator.SetTrigger(_shoot);
    }
}
