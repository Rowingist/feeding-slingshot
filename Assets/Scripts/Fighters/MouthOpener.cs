using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SkinnedMeshRenderer))]
public class MouthOpener : MonoBehaviour
{
    [SerializeField] private FoodSpawner _spawner;
    [SerializeField] private Transform _mouth;
    [SerializeField] private Transform _spawnPoint;

    private SkinnedMeshRenderer _sizeChanger;

    private float _currentMouthOpennes, _maxDistance;

    private void Awake()
    {
        _sizeChanger = GetComponent<SkinnedMeshRenderer>();
        _maxDistance = Vector3.Distance(_mouth.position, _spawnPoint.position);
    }

    private void Update()
    {
        _currentMouthOpennes = Vector3.Distance(_mouth.position, _spawner.GetSpawnedFoodPosition());
        _sizeChanger.SetBlendShapeWeight(3, _currentMouthOpennes);

        print(_currentMouthOpennes);
    }
}
