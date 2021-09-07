using UnityEngine;

public class FoodFromGateMover : MonoBehaviour
{
    private float _speed = 4f;

    private GameObject _target;

    private void FixedUpdate()
    {
        transform.localPosition = Vector3.MoveTowards(transform.localPosition, _target.transform.position, _speed * Time.deltaTime);
    }

    public void SetTarget(GameObject food)
    {
       _target = food;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out FighterSizeChanger fighter) || other.TryGetComponent(out ForbidenArea forbidenArea))
        {
            Destroy(gameObject);
        }
    }
}