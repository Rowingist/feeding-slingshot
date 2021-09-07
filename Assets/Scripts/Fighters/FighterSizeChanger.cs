using System;
using UnityEngine;

public class FighterSizeChanger : MonoBehaviour
{
    [SerializeField] private float _scaleFactor;
    [SerializeField] private SkinnedMeshRenderer _skinnedMeshRenderer;
    [SerializeField] private ParticleSystem _particleSystem;

    public float CurrentSkinSize { get; private set; }
    public float ScaleFactor => _scaleFactor;

    public event Action EatenFood;
    public event Action Lost;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Food food) || other.TryGetComponent(out FoodFromGateMover spawnedFood)|| other.TryGetComponent(out EnemyFood enemyFood))
        {
            CurrentSkinSize += _scaleFactor;
            _skinnedMeshRenderer.SetBlendShapeWeight(0, CurrentSkinSize);
            EatenFood?.Invoke();
            _particleSystem.Play();
        }

        if(other.TryGetComponent(out Water water))
        {
            Lost?.Invoke();
        }
    }
}