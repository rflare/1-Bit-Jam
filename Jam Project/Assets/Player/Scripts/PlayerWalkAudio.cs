using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWalkAudio : MonoBehaviour
{
    bool _isMoving;
    AudioSource _source;
    void Awake()
    {
        _source = GetComponent<AudioSource>();
    }
    void Start()
    {
        IEnumerator stuff()
        {
            for(; ; )
            {
                if(_isMoving)
                {
                    _source.Play();
                    yield return new WaitForSeconds(0.5f);
                }
                else
                {
                    yield return null;
                }
            }
        }
        StartCoroutine(stuff());
    }

    void Update()
    {
        _isMoving = PlayerContext.Instance.Move.magnitude > 0.1f && PlayerContext.Instance.IsGrounded;
    }
}
