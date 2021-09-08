using UnityEngine;

[RequireComponent(typeof(Animator))]
public class SlingshotAnimation : MonoBehaviour
{
    private Animator _amimator;
    private PlayerInput _mouseService;

    private string _aiming = "Aim";
    private string _shoot = "Shoot";

    private void Awake()
    {
        _amimator = GetComponent<Animator>();
        _mouseService = GetComponent<PlayerInput>();
    }

    private void OnEnable()
    {
        _mouseService.Dragging += OnAiming;
        _mouseService.LeftButtonReleased += OnShoot;
    }

    private void OnDisable()
    {
        _mouseService.Dragging -= OnAiming;
        _mouseService.LeftButtonReleased -= OnShoot;
    }

    private void OnAiming()
    {
        _amimator.SetBool(_aiming, true);
    }

    private void OnShoot()
    {
        _amimator.SetBool(_aiming, false);
        _amimator.SetTrigger(_shoot);
    }
}
