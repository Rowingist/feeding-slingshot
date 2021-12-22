using UnityEngine;

public class FighterSmoothMover : MonoBehaviour
{
    [SerializeField] private float _speed = 0.1f;

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, transform.position - Vector3.right, Time.deltaTime * _speed);
    }
}