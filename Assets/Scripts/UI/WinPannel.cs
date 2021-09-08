using System.Collections;
using UnityEngine;

public class WinPannel : MonoBehaviour
{
    [SerializeField] private Game _game;
    [SerializeField] private GameObject _winPannel;
    [SerializeField] private GameObject _losePannel;

    private void OnEnable()
    {
        _game.Won += OnActivateWinPannel;
        _game.Over += OnActivateLosePannel;
    }

    private void OnDisable()
    {
        _game.Won -= OnActivateWinPannel;
        _game.Over -= OnActivateLosePannel;
    }

    private void OnActivateWinPannel()
    {
        StartCoroutine(SetActivationDelay(_winPannel, 2f));
    }

    private void OnActivateLosePannel()
    {
        StartCoroutine(SetActivationDelay(_losePannel, 2f));
    }

    private IEnumerator SetActivationDelay(GameObject pannel, float delay)
    {
        yield return new WaitForSeconds(delay);
        pannel.gameObject.SetActive(true);
    }
}