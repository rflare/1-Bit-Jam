public abstract class PlayerBaseState
{
    public abstract void Start(PlayerContext player);

    public abstract void Update(PlayerContext player);

    public abstract void Stop(PlayerContext player);

    public abstract void CheckSwitchStates(PlayerContext player);

    protected void SwitchStates(PlayerContext player, PlayerBaseState newState)
    {
        Stop(player);
        player.CurrentState = newState;
        newState.Start(player);
    }
}