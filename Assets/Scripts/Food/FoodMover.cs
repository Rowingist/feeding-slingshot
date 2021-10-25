using UnityEngine;

public class FoodMover : MonoBehaviour
{
    [SerializeField] private float _speed = 10f;

    private Food _food;
    private Path _flightPath;

    private float _instantTime;

    private void OnEnable()
    {
        _food = GetComponent<Food>();
        _food.enabled = false;
        _instantTime = 0f;
    }

    private void Update()
    {
        if (_instantTime < _flightPath.Length)
        {
            _instantTime += Time.deltaTime * _speed;
            transform.position = _flightPath.GetPositionAtTime(_instantTime);
        }
    }

    public void IntitPath(Path currentPath)
    {
        _flightPath = currentPath;
    }
}