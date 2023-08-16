using System.Collections;
using UnityEngine;

public abstract class PlayerAttackObserver : MonoBehaviour
{
    public abstract void NotifyAttack();
    void OnEnable()
    {
        StartCoroutine(AddAttackObserver());
    }

    void OnDisable()
    {
        PlayerContext.Instance.RemoveAttackObserver(this);
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