using UnityEngine;
using UnityEngine.SceneManagement;

public class GameRestart : MonoBehaviour
{
    [SerializeField] private PlayerInput _playerInput;

    private string _currentScene;

    private void Awake()
    {
        _currentScene = SceneManager.GetActiveScene().name;
    }

    private void Update()
    {
        if (UnityEngine.Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene(_currentScene, LoadSceneMode.Single);
        }
    }
}