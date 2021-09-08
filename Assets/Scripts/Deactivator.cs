using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deactivator : MonoBehaviour
{
    [SerializeField] private Game _game;

    private void OnEnable()
    {
        _game.Over += OnDeactivate;
    }

    private void OnDisable()
    {
        _game.Over -= OnDeactivate;
    }

    private void OnDeactivate()
    {
        gameObject.SetActive(false);
    }
}
