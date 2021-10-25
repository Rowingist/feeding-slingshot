using UnityEngine;

public class FighterFastMover : MonoBehaviour
{
    private Vector3 _targetPosition;
    private float _speed;

    private void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, _targetPosition, Time.deltaTime * _speed);
    }

    public void SetParameters(Vector3 targetPosition, float speed)
    {
        if (transform.localPosition == targetPosition)
            enabled = false;

        _targetPosition = targetPosition;
        _speed = speed;
    }
}
