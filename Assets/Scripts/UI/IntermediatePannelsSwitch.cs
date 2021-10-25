using System.Collections;
using UnityEngine;

public class IntermediatePannelsSwitch : MonoBehaviour
{
    [SerializeField] private GamePointsCounter _pointsCounter;
    [SerializeField] private GameObject _winPannel;
    [SerializeField] private GameObject _losePannel;

    private void OnEnable()
    {
        _pointsCounter.GameWasWon += OnActivateWinPannel;
        _pointsCounter.GameWasLost += OnActivateLosePannel;
    }

    private void OnDisable()
    {
        _pointsCounter.GameWasWon -= OnActivateWinPannel;
        _pointsCounter.GameWasLost -= OnActivateLosePannel;
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