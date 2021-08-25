using System.Collections;
using UnityEngine;

public class Gate : MonoBehaviour
{
    [SerializeField] private GameObject _foodPrefab;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Food food))
        {
            for (int i = 0; i < transform.localScale.x * 10; i++)
            {
                GameObject newFood = Instantiate(_foodPrefab, transform.localPosition + new Vector3(0, 0, Random.Range(-2f, 2f)), transform.localRotation);
            }

            Deactivate();
        }
    }

    

    private void Deactivate()
    {
        gameObject.SetActive(false);
    }
}
