using UnityEngine;

public class NewFoodMover : MonoBehaviour
{
    [SerializeField] private Vector3 _target;

    private float _speed = 5f;


    private void Update()
    {
        transform.localPosition = Vector3.MoveTowards(transform.localPosition, _target, Time.deltaTime * _speed);
    }
}
