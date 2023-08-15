using UnityEngine;

public class PlayerDarkState : PlayerBaseState
{
    public override void Start(PlayerContext player)
    {
        player.ChangeSprite(player.DarkSprite);
    }

    public override void Update(PlayerContext player)
    {
        player.HandleMovement();
        if(player.IsGrounded) player.HandleJump();
        player.HandleDirection();
    }
    public override void Stop(PlayerContext player)
    {

    }

    public override void CheckSwitchStates(PlayerContext player)
    {
        if (player.IsTouchingWhite())
            SwitchStates(player, new PlayerLightState());
    }
}