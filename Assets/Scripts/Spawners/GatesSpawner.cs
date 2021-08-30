using UnityEngine;

public class GatesSpawner : ObjectPool
{
    [SerializeField] private GameObject _prefab;
    [SerializeField] private Transform[] _spawnPoints;

    private float _timeBetweenSpawn = 5f;
    private float _elapsedTime = 0f;

    private void Start()
    {
        Initialize(_prefab);
        Spawn();
    }

    private void Update()
    {
        _elapsedTime += Time.deltaTime;
        if(_elapsedTime >= _timeBetweenSpawn)
            Spawn();
    }

    public void Spawn()
    {
        if (TryGetObject(out GameObject gate))
        {
            int random = Random.Range(0, _spawnPoints.Length);
            SetGate(gate, _spawnPoints[random].position);
            _elapsedTime = 0;
        }
    }

    private void SetGate(GameObject gate, Vector3 spawnPoint)
    {
        if (GetSpawnPermition())
            return;

        gate.SetActive(true);
        gate.transform.position = spawnPoint;
    }
}