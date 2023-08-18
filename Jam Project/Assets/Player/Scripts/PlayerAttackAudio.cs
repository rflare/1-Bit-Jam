using UnityEngine;

public class PlayerAttackAudio : PlayerAttackObserver
{
    AudioSource _source;

    void Awake()
    {
        _source = GetComponent<AudioSource>();
    }
    public override void NotifyAttack()
    {
        _source.Play();
    }
}