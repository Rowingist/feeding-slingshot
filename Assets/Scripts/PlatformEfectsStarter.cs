using UnityEngine;

public class PlatformEfectsStarter : MonoBehaviour
{
    [SerializeField] private Game _game;
    [SerializeField] private ParticleSystem[] _playerConfettiEffects;

    private void OnEnable()
    {
        _game.Over += OnStartEffects;
    }

    private void OnDisable()
    {
        _game.Over -= OnStartEffects;
    }

    private void OnStartEffects()
    {
        foreach (var effect in _playerConfettiEffects)
        {
            effect.Play();
        }
    }
}
