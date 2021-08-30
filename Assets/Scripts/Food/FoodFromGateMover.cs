using System.Collections.Generic;
using UnityEngine;

public class FoodFromGateMover : MonoBehaviour
{
    private float _speed = 7f;

    private GameObject _target;

    private void FixedUpdate()
    {
        transform.localPosition = Vector3.MoveTowards(transform.localPosition, _target.transform.position, _speed * Time.deltaTime);
    }

    public void SetTarget(GameObject food)
    {
       _target = food;
    }
}