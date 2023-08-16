using UnityEngine;

public class PlayerCastAttack : PlayerAttackObserver
{
    public override void NotifyAttack()
    {
        Debug.Log("Casting Collider");
    }
}