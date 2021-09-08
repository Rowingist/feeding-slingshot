using UnityEngine;
using TMPro;

public class ScoreText : MonoBehaviour
{
    [SerializeField] private FighterSizeChanger _playerFighter;

    private TMP_Text _score;

    private int _additionStep = 1;

    private void Awake()
    {
        _score = GetComponent<TMP_Text>();
    }

    private void OnEnable()
    {
        _playerFighter.EatenFood += OnScoreChanged;
    }

    private void OnDisable()
    {
        _playerFighter.EatenFood -= OnScoreChanged;
    }

    private void OnScoreChanged()
    {
        _score.text = _additionStep.ToString();
        _additionStep++;
    }
}