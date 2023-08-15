using System.Collections;
using UnityEngine;

public class PlayerAttackEffect : MonoBehaviour, IPlayerAttackObserver
{
    //private properties
    Animator _anim;

    //Private Methods

    void OnEnable()
    {
        StartCoroutine(AddAttackObserver());
    }

    void OnDisable()
    {
        PlayerContext.Instance.RemoveAttackObserver(this);
    }

    void Awake()
    {
        _anim = GetComponent<Animator>();
    }
    void Update()
    {

    }

    public void NotifyAttack()
    {
        _anim.SetTrigger("Attack");
    }

    IEnumerator AddAttackObserver()
    {
        for (; ; )
        {
            if (PlayerContext.Instance == null)
            {
                yield return null;
            }
            else break;
        }
        PlayerContext.Instance.AddAttackObserver(this);
    }
}