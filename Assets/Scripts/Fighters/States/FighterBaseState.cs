public abstract class FighterBaseState 
{
    protected readonly Fighter _fighter;
    protected readonly IStationStateSwitcher _stateSwitcher;

    protected FighterBaseState(Fighter fighter, IStationStateSwitcher stateSwitcher)
    {
        _fighter = fighter;
        _stateSwitcher = stateSwitcher;
    }

    public abstract void Start();
    public abstract void Stop();
    public abstract void Idle();
    public abstract void Run();
    public abstract void Eat();
    public abstract void ChangeSize();
    public abstract void Win();
    public abstract void Lose();
}
