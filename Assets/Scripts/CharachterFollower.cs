using UnityEngine;
using DG.Tweening;

public class CharachterFollower : MonoBehaviour
{
    [SerializeField] private Transform _characterFollowPoint;
    [SerializeField, Range(0f, 10)] private float _offsetX;

    private float _speed = 10f;
    private Vector3 _newPosition;

    private void Update()
    {
        _newPosition = transform.position;
        _newPosition.x = _characterFollowPoint.position.x + _offsetX;
        transform.position = Vector3.MoveTowards(transform.position, _newPosition, Time.deltaTime * _speed);
    }
}
