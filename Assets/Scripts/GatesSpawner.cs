using UnityEngine;
using Zenject;

public class GatesSpawner : ObjectPool
{
    [SerializeField] private GameObject _prefab;
    [SerializeField] private Transform[] _spawnPoints;

    private IMouseService _mouseService;


    private void Start()
    {
        Initialize(_prefab);
    }

    [Inject]
    private void Construct(IMouseService mouseService)
    {
        _mouseService = mouseService;
        _mouseService.MouseLeftButtonPressed += OnSpawn;
    }

    private void OnDisable()
    {
        _mouseService.MouseLeftButtonPressed -= OnSpawn;
    }

    private void SetGate(GameObject gate, Vector3 spawnPoint)
    {
        float random = Random.Range(0.1f, 0.4f);
        gate.SetActive(true);
        gate.transform.position = spawnPoint;
        gate.transform.localScale *= random;
    }

    public void OnSpawn()
    {
        int random = Random.Range(0, _spawnPoints.Length);
        if (TryGetObject(out GameObject gate))
        {
            SetGate(gate, _spawnPoints[random].position);
        }
    }
}
