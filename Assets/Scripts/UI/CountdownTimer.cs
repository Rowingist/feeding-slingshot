using System.Collections;
using UnityEngine;
using TMPro;
using System;

public class CountdownTimer : MonoBehaviour
{
    [SerializeField] private int _delaySecondsQuantity;
    [SerializeField] private Animator _animator;
    [SerializeField] private TMP_Text _countdownDisplay;
    
    private StartButton _startButton;
    private int _zoomTriggetHash;

    public event Action GameStarted;

    private void Awake()
    {
        _startButton = GetComponentInChildren<StartButton>();
        _zoomTriggetHash = Animator.StringToHash("Zoom");
    }

    private void OnEnable()
    {
        _startButton.Pushed += OnStartCountdow;
    }

    private void OnDisable()
    {
        _startButton.Pushed -= OnStartCountdow;
    }

    private void OnStartCountdow()
    {
        _countdownDisplay.gameObject.SetActive(true);
        StartCoroutine(CountdownToStart(1f));
    }

    private IEnumerator CountdownToStart(float delay)
    {
        while(_delaySecondsQuantity > 0)
        {
            _animator.SetTrigger(_zoomTriggetHash);
            _countdownDisplay.text = _delaySecondsQuantity.ToString();

            yield return new WaitForSeconds(delay);

            _delaySecondsQuantity--;
        }

        _countdownDisplay.text = "Start!";

        yield return new WaitForSeconds(delay);

        _countdownDisplay.gameObject.SetActive(false);
        GameStarted?.Invoke();
    }
}