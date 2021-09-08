using UnityEngine;

[RequireComponent(typeof(PlayerInput))]
public class Instruction : MonoBehaviour
{
    [SerializeField] private PlayerInput _playerInput;

    private void OnEnable()
    {
        _playerInput.Dragging += OnDeactivatePanel;
    }

    private void OnDisable()
    {
        _playerInput.Dragging += OnDeactivatePanel;
    }

    private void OnDeactivatePanel()
    {
        gameObject.SetActive(false);
    }
}
