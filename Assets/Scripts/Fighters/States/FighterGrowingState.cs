using UnityEngine;
using UnityEngine.UI;

public class FighterGrowingState : FighterBaseState
{
    public FighterGrowingState(Fighter fighter, Text statusText, IStationStateSwitcher stateSwitcher)
        : base(fighter, statusText, stateSwitcher)
    {

    }

    public override void Decreace()
    {
        throw new System.NotImplementedException();
    }

    public override void Grow()
    {
        throw new System.NotImplementedException();
    }

    public override void Idle()
    {
        throw new System.NotImplementedException();
    }

    public override void Push()
    {
        throw new System.NotImplementedException();
    }

    public override void Run()
    {
        throw new System.NotImplementedException();
    }

    public override void Start()
    {
        throw new System.NotImplementedException();
    }

    public override void Stop()
    {
        throw new System.NotImplementedException();
    }

    public override void OverGame()
    {
        throw new System.NotImplementedException();
    }
}
