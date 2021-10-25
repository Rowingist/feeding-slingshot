using UnityEngine.Playables;
using UnityEngine;

public class CameraFirstMovementTrigger : MonoBehaviour
{
    [SerializeField] private StartButton _startButton;

    private PlayableDirector _camerasSwitcher;

    private void Awake()
    {
        _camerasSwitcher = GetComponent<PlayableDirector>();
    }

    private void OnEnable()
    {
        _startButton.Pushed += OnStartMovement;
    }

    private void OnDisable()
    {
        _startButton.Pushed += OnStartMovement;
    }

    private void OnStartMovement()
    {
        _camerasSwitcher.enabled = true;
    }
}
