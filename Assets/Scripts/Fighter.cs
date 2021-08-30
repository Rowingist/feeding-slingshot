using System;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Fighter : MonoBehaviour
{
    [SerializeField] private SkinnedMeshRenderer _skinnedMeshRenderer;

    private int scaleStep = 0;

    public event Action Killed;

    private void OnTriggerEnter(Collider other)
    {
        scaleStep += 2;
        if (other.TryGetComponent(out Food food))
        {
            _skinnedMeshRenderer.SetBlendShapeWeight(0, scaleStep);
        }

        if(other.TryGetComponent(out Enemy enemy))
        {
            _skinnedMeshRenderer.SetBlendShapeWeight(0, scaleStep);
        }

        if (other.TryGetComponent(out FoodFromGateMover newFoodMover))
        {
            Destroy(newFoodMover.gameObject);
        }

        if (other.TryGetComponent(out Water water))
        {
            Killed?.Invoke();
            Destroy(water.gameObject);
        }
    }
}