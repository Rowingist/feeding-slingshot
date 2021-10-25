using UnityEngine;

public class MoverSwitch : MonoBehaviour
{
    [SerializeField] private Fighter _fighter;
    [SerializeField] private FighterSmoothMover _playerMover;
    [SerializeField] private FighterSmoothMover _enemysMover;

    private void OnEnable()
    {
        _fighter.StartedPush += OnActiwateMover;
    }

    private void OnDisable()
    {
        _fighter.StartedPush -= OnActiwateMover;
    }

    private void OnActiwateMover()
    {
        _playerMover.enabled = true;
        _enemysMover.enabled = true;
    }
}
