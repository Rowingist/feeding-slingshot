using UnityEngine;

public class FightersMover : MonoBehaviour
{
    [SerializeField] private SkinnedMeshRenderer _playerFighter;
    [SerializeField] private SkinnedMeshRenderer _enemyFighter;

    private float _speed = 0.2f;
    private float _xShift;

    private void Update()
    {
        _xShift = _playerFighter.GetBlendShapeWeight(0) - _enemyFighter.GetBlendShapeWeight(0);
        Vector3 newPosition = new Vector3(_xShift / 100, transform.localPosition.y, transform.localPosition.z);
        transform.localPosition = Vector3.MoveTowards(transform.localPosition, newPosition, _speed * Time.deltaTime);
    }
}
