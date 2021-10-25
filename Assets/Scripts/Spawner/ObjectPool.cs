using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject _container;
    [SerializeField] private int _capacity;

    private int _currentPrefabNumber = 0, _nextPrefabNumber = 0;

    private Dictionary<GameObject, Sprite> _pool = new Dictionary<GameObject, Sprite>();

    protected void Initialize(GameObject[] prefabs, Sprite[] prefabIcons)
    {
        for (int i = 0; i < _capacity; i++)
        {
            int randIndex = Random.Range(0, prefabs.Length);
            GameObject spawnedPrefab = Instantiate(prefabs[randIndex], _container.transform);
            Sprite spawnedImage = Instantiate(prefabIcons[randIndex], _container.transform);
            spawnedPrefab.SetActive(false);

            _pool.Add(spawnedPrefab, spawnedImage);
        }
    }

    protected bool TryGetObject(out GameObject result)
    {
        result = _pool.Keys.ElementAt(_currentPrefabNumber);

        return result != null;
    }

    protected Sprite TryGetObject()
    {
        bool isActive = _pool.Keys.ElementAt(_currentPrefabNumber).activeSelf;

        while (isActive)
        {
            _nextPrefabNumber = Random.Range(0, _capacity);
            isActive = _pool.Keys.ElementAt(_nextPrefabNumber).activeSelf;
        }

        if (_pool.TryGetValue(_pool.Keys.ElementAt(_nextPrefabNumber), out Sprite nextPrefabIcon))
        {
            _currentPrefabNumber = _nextPrefabNumber;
            return nextPrefabIcon;
        }
        else
        {
            return null;
        }
    }
}