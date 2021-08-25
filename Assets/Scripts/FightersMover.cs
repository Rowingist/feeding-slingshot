using UnityEngine;

public class FightersMover : MonoBehaviour
{
    [SerializeField] private PlayerFighter _playerFighter;
    [SerializeField] private EnemyFighter _enemyFighter;

    private float _xShift;

    private void Update()
    {
        _xShift = _playerFighter.transform.localScale.x - _enemyFighter.transform.localScale.x;
        transform.localPosition = new Vector3(_xShift, transform.localPosition.y, transform.localPosition.z);
    }
}
