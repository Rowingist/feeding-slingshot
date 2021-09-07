using System.Collections;
using UnityEngine;
using DG.Tweening;

public class Gate : MonoBehaviour
{
    [SerializeField] private int _multiplyer = 1;
    [SerializeField] private GameObject _smokeEffect;
    [SerializeField] private GameObject _foodPrefab;

    private float _randomX, _randomY;

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
                _randomX = Random.Range(-1f, 1f);
                _randomY = Random.Range(-0.5f, 0.5f);
                Vector3 spread = new Vector3(_randomX, _randomY, Random.Range(1f, 3f));
                GameObject newFood = Instantiate(_foodPrefab, transform.localPosition + spread, transform.localRotation);
                FoodFromGateMover foodFromGateMover = newFood.AddComponent(typeof(FoodFromGateMover)) as FoodFromGateMover;
                MeshFilter meshFilter = newFood.AddComponent(typeof(MeshFilter)) as MeshFilter; ;
                MeshRenderer meshRenderer = newFood.AddComponent(typeof(MeshRenderer)) as MeshRenderer; ;
                meshFilter.mesh = food.GetComponent<MeshFilter>().mesh;
                meshRenderer.material = food.GetComponent<MeshRenderer>().material;
                foodFromGateMover.SetTarget(food.gameObject);
            }

            _smokeEffect.gameObject.SetActive(true);
            StartCoroutine(Deactivate());
        }
    }

    private IEnumerator Deactivate()
    {
        yield return new WaitForSeconds(0.3f);
        _smokeEffect.gameObject.SetActive(false);
        gameObject.SetActive(false);
    }
}
