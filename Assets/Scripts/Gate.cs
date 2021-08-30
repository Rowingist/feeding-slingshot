using UnityEngine;

public class Gate : MonoBehaviour
{
    [SerializeField] private int _multiplyer = 1;

    private GameObject _foodPrefab;
    private float _randomX, _randomY;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Food food))
        {
            for (int i = 0; i < _multiplyer; i++)
            {
                _foodPrefab = food.gameObject;
                _randomX = Random.Range(-0.5f, 0.5f);
                _randomY = Random.Range(-0.5f, 0.5f);
                Vector3 spread = new Vector3(_randomX, _randomY, 0.3f);
                GameObject newFood = Instantiate(_foodPrefab, transform.localPosition + spread, transform.localRotation);
                FoodFromGateMover foodFromGateMover = newFood.AddComponent(typeof(FoodFromGateMover)) as FoodFromGateMover;

                if (newFood.TryGetComponent(out FoodFromGateMover newFoodMover))
                {
                    newFoodMover.SetTarget(food.gameObject);
                }
            }

            Deactivate();
        }
    }

    private void Deactivate()
    {
        gameObject.SetActive(false);
    }
}
