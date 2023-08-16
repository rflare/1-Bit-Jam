using UnityEngine;

public class EnemyLand : BaseEnemy
{
    Collider2D _c2D;


    void Awake()
    {
        _c2D = GetComponent<Collider2D>();
        Health = 3;
    }

    protected override void Behaviour()
    {

    }

    void OnCollisionEnter2D(Collision2D c)
    {
        if(c.collider == PlayerContext.Instance.C2D)
        {
            PlayerContext.Instance.Damage((Vector2) transform.position);
        }    
    }
}