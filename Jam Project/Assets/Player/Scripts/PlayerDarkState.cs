using UnityEngine;

public class PlayerDarkState : PlayerBaseState
{
    public override void Start(PlayerContext player)
    {
        Debug.Log("Entered Dark State");
        player.ChangeSprite(player.DarkSprite);
    }

    public override void Update(PlayerContext player)
    {
        player.HandleMovement();
        if(player.IsGrounded) player.HandleJump();
    }
    public override void Stop(PlayerContext player)
    {
        Debug.Log("Exited Dark State");
    }

    public override void CheckSwitchStates(PlayerContext player)
    {
        if (player.IsTouchingWhite())
            SwitchStates(player, new PlayerLightState());
    }
}