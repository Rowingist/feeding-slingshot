using UnityEngine;

public class SizeChanger : MonoBehaviour
{
    [SerializeField] private SkinnedMeshRenderer _skinnedMeshRenderer;
    [SerializeField, Range(1, 20)] private float _foodScalingFactor = 5f;

    private Fighter _fighter;

    public float CurrentSkinSize { get; private set; }

    private void Awake()
    {
        _fighter = GetComponent<Fighter>();
        CurrentSkinSize = _skinnedMeshRenderer.GetBlendShapeWeight(0);
    }

    private void OnEnable()
    {
        _fighter.EatenFreshFood += OnIncreaseSkinSize;
        _fighter.EatenSpoiledFood += OnDecreaseSkinSize;
    }

    private void OnDisable()
    {
        _fighter.EatenFreshFood -= OnIncreaseSkinSize;
        _fighter.EatenSpoiledFood += OnDecreaseSkinSize;
    }

    private void OnIncreaseSkinSize()
    {
        if (_skinnedMeshRenderer.GetBlendShapeWeight(0) >= 100f)
            return;

        _skinnedMeshRenderer.SetBlendShapeWeight(0, _skinnedMeshRenderer.GetBlendShapeWeight(0) + _foodScalingFactor);
    }

    private void OnDecreaseSkinSize()
    {
        if (_skinnedMeshRenderer.GetBlendShapeWeight(0) <= 0f)
            return;

        _skinnedMeshRenderer.SetBlendShapeWeight(0, _skinnedMeshRenderer.GetBlendShapeWeight(0) - _foodScalingFactor);
    }
}