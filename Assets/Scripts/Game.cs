using UnityEngine;
using UnityEngine.Events;

public class Game : MonoBehaviour
{
    [SerializeField] private Fighter _playerFighter;
    [SerializeField] private Fighter _enemyFighter;

    public event UnityAction GameOver;

    private void OnEnable()
    {
        _playerFighter.Killed += OnEndGame;
        _enemyFighter.Killed += OnEndGame;
    }

    private void OnDisable()
    {
        _playerFighter.Killed -= OnEndGame;
        _enemyFighter.Killed -= OnEndGame;
    }

    private void OnEndGame()
    {
        GameOver?.Invoke();
    }
}
