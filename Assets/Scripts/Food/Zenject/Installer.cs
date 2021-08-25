using Zenject;

public class Installer : MonoInstaller
{
    public PlayerInput PlayerInputPrefab;

    public override void InstallBindings()
    {
        BindMouseService();
    }

    private void BindMouseService()
    {
        Container.Bind<IMouseService>().To<PlayerInput>().FromComponentInNewPrefab(PlayerInputPrefab).AsSingle();
    }
}
