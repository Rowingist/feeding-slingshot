using UnityEngine;
using UnityEngine.UI;

public abstract class FighterBaseState 
{
    protected readonly Fighter _fighter;
    protected readonly Text _statusText;
    protected readonly IStationStateSwitcher _stateSwitcher;

    protected FighterBaseState(Fighter fighter, Text statusText, IStationStateSwitcher stateSwitcher)
    {
        _fighter = fighter;
        _statusText = statusText;
        _stateSwitcher = stateSwitcher;
    }

    public abstract void Start();
    public abstract void Stop();
    public abstract void Push();
    public abstract void Grow();
    public abstract void Decreace();
    public abstract void OverGame();
    public abstract void Idle();
    public abstract void Run();

}
