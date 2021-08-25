using Zenject;
using UnityEngine;

public class PlayerInstaller : MonoInstaller
{
    public Transform StartPoint;
    public GameObject FoodPrefab;
    public Transform[] ParabolaRoots;
    public LineRenderer LineRenderer;

    public override void InstallBindings()
    {
        BindParabolaRoots();
        BindLineRenderer();
        BindFood();
    }

    private void BindParabolaRoots()
    {
        Container.Bind<Transform[]>().FromInstance(ParabolaRoots).AsCached();
    }

    private void BindLineRenderer()
    {
        Container.Bind<LineRenderer>().FromInstance(LineRenderer).AsSingle();
    }

    private void BindFood()
    {
        FoodMover foodMover = Container.InstantiatePrefabForComponent<FoodMover>(FoodPrefab, StartPoint.position, Quaternion.identity, null);

        Container.Bind<FoodMover>().FromInstance(foodMover).AsSingle();
    }
}