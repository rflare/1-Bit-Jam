using System.Collections.Generic;
using UnityEngine;

public class Flag : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D c)
    {
        if(c.gameObject == PlayerContext.Instance.gameObject)
        {
            GameManager.Instance.GotFlag();
        }
    }
}