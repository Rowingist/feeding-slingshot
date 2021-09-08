using System.Collections;
using UnityEngine;
using DG.Tweening;

public class Gate : MonoBehaviour
{
    [SerializeField] private int _multiplyer = 1;
    [SerializeField] private GameObject _smokeEffect;
    [SerializeField] private GameObject _foodPrefab;

    private float _randomX, _randomY, _randomZ;

    private void Start()
    {
        transform.DOMove(transform.position + new Vector3(0, Random.Range(-0.5f, 0.5f), 0), 4).SetEase(Ease.Linear).SetLoops(-1, LoopType.Yoyo);
        transform.DORotate(new Vector3(0, 180, 0), 3f).SetLoops(-1, LoopType.Incremental).SetEase(Ease.Linear);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Food food))
        {
            for (int i = 0; i < _multiplyer; i++)
            {
                RandomizePsition();
                CopyFlyingFood(food);
            }

            _smokeEffect.gameObject.SetActive(true);
            StartCoroutine(SetDeactivationDelay(0.3f));
        }
    }

    private void CopyFlyingFood(Food food)
    {
        Vector3 spread = new Vector3(_randomX, _randomY, _randomZ);
        GameObject newFood = Instantiate(_foodPrefab, transform.localPosition + spread, Quaternion.Euler(spread));
        FoodFromGateMover foodFromGateMover = newFood.AddComponent(typeof(FoodFromGateMover)) as FoodFromGateMover;
        MeshFilter meshFilter = newFood.AddComponent(typeof(MeshFilter)) as MeshFilter; ;
        MeshRenderer meshRenderer = newFood.AddComponent(typeof(MeshRenderer)) as MeshRenderer; ;
        
        meshFilter.mesh = food.GetComponent<MeshFilter>().mesh;
        meshRenderer.material = food.GetComponent<MeshRenderer>().material;
        foodFromGateMover.SetTarget(food.gameObject);
    }

    private void RandomizePsition()
    {
        _randomX = Random.Range(-1f, 1f);
        _randomY = Random.Range(-0.5f, 0.5f);
        _randomZ = Random.Range(0.5f, 1f);
    }

    private IEnumerator SetDeactivationDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        _smokeEffect.gameObject.SetActive(false);
        gameObject.SetActive(false);
    }
}
