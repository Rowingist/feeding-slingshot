using Zenject;
using UnityEngine;

public class ObjectInstaller : MonoInstaller
{
    public Transform[] ParabolaRoots;

    public override void InstallBindings()
    {
        BindParabolaRoots();
    }

    private void BindParabolaRoots()
    {
        Container.Bind<Transform[]>().FromInstance(ParabolaRoots).AsCached();
    }
}