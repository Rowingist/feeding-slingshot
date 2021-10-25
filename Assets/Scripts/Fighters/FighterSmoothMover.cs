using UnityEngine;

[RequireComponent(typeof(Fighter))]
public class FighterSmoothMover : MonoBehaviour
{
    [SerializeField] private float _speed = 0.1f;
    
    private Fighter _fighter;

    private void Awake()
    {
        _fighter = GetComponent<Fighter>();
    }

    private void OnEnable()
    {
        _fighter.Won += OnDeactivate;
        _fighter.Lost += OnDeactivate;
    }

    private void OnDisable()
    {
        _fighter.Won -= OnDeactivate;
        _fighter.Lost -= OnDeactivate;
    }

    private void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, transform.position - Vector3.right, Time.deltaTime * _speed);
    }

    private void OnDeactivate()
    {
        enabled = false;
    }
}
