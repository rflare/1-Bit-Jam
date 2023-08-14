using UnityEngine;

public class PlayerLightState : PlayerBaseState
{
    public override void Start(PlayerContext player)
    {
        Debug.Log("Entered Light State");
        player.ChangeSprite(player.LightSprite);
    }

    public override void Update(PlayerContext player)
    {
        player.HandleMovement();
        player.HandleBite();
    }
    public override void Stop(PlayerContext player)
    {
        Debug.Log("Exited Light State");
    }

    public override void CheckSwitchStates(PlayerContext player)
    {
        if (player.IsTouchingBlack()) SwitchStates(player, new PlayerDarkState());
    }
}