using System.Collections;
using UnityEngine;

public abstract class PlayerAttackObserver : MonoBehaviour
{
    public abstract void NotifyAttack();

    void OnEnable()
    {
        IEnumerator addAttackObserver()
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
        StartCoroutine(addAttackObserver());
    }
    void OnDisable()
    {
        PlayerContext.Instance.RemoveAttackObserver(this);
    }
}