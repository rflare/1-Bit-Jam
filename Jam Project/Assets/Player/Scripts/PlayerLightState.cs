using UnityEngine;

public class PlayerLightState : PlayerBaseState
{
    public override void Start(PlayerContext player)
    {
        player.ChangeSprite(player.LightSprite);
    }

    public override void Update(PlayerContext player)
    {
        player.HandleMovement();
        player.HandleBite();
        player.HandleDirection();
    }
    public override void Stop(PlayerContext player)
    {

    }

    public override void CheckSwitchStates(PlayerContext player)
    {
        if (player.IsTouchingBlack()) SwitchStates(player, new PlayerDarkState());
    }
}