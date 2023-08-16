using System.Collections.Generic;
using UnityEngine;

public class PlayerCastAttack : PlayerAttackObserver
{
    Collider2D _c2D;

    void Awake()
    {
        _c2D = GetComponent<Collider2D>();
    }
    public override void NotifyAttack()
    {
        List<RaycastHit2D> hits = new List<RaycastHit2D>();

        _c2D.Cast(Vector2.up, new ContactFilter2D().NoFilter(), hits);

        hits = hits.FindAll(e => e.transform.gameObject.layer == 8);

        foreach(RaycastHit2D hit in hits)
        {
            hit.transform.GetComponent<BaseEnemy>().Health -= 1;
        }
    }
}