using System.Collections;
using UnityEngine;

public class PlayerAttackEffect : PlayerAttackObserver
{
    //private properties
    Animator _anim;

    //Private Methods


    void Awake()
    {
        _anim = GetComponent<Animator>();
    }
    void Update()
    {

    }

    public override void NotifyAttack()
    {
        _anim.SetTrigger("Attack");
    }
}