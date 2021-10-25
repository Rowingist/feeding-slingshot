using UnityEngine;
using TMPro;

public class PlayerPointsCounter : MonoBehaviour
{
    [SerializeField] private Fighter _player;
    [SerializeField] private TMP_Text _points;

    private void OnEnable()
    {
        _player.EatenFreshFood += OnUpdateText;
        _player.EatenSpoiledFood += OnUpdateText;
    }

    private void OnDisable()
    {
        _player.EatenFreshFood -= OnUpdateText;
        _player.EatenSpoiledFood -= OnUpdateText;
    }

    private void OnUpdateText()
    {
        _points.text = _player.PlayPoints.ToString();
    }
}
