using UnityEngine;
using UnityEngine.Playables;

[RequireComponent(typeof(PlayableDirector))]
public class CameraMover : MonoBehaviour
{
    [SerializeField] private GamePointsCounter _gamePointsCounter;

    private PlayableDirector _camerasSwitcher;

    private void Awake()
    {
        _camerasSwitcher = GetComponent<PlayableDirector>();
    }

    private void OnEnable()
    {
        _gamePointsCounter.GameWasWon += OnStartCameraMovement;
        _gamePointsCounter.GameWasLost += OnStartCameraMovement;
    }

    private void OnDisable()
    {
        _gamePointsCounter.GameWasWon -= OnStartCameraMovement;
        _gamePointsCounter.GameWasLost -= OnStartCameraMovement;
    }

    private void OnStartCameraMovement()
    {
        _camerasSwitcher.enabled = true;
    }
}