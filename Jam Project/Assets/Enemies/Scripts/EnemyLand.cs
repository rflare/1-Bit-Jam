using UnityEngine;

public class EnemyLand : BaseEnemy
{
    public enum State
    {
        Unwary,
        Alert
    }

    

    Collider2D _c2D;
    Rigidbody2D _rb2D;
    SpriteRenderer _sp;

    [SerializeField] float _speed;
    [SerializeField] State _state;
    [SerializeField] float _unwaryDirChange;
    [SerializeField] float _detectionDistance;


    [SerializeField] Sprite _normalPNG;
    [SerializeField] Sprite _angryPNG;


    void Awake()
    {
        _c2D = GetComponent<Collider2D>();
        _rb2D = GetComponent<Rigidbody2D>();
        _sp = GetComponent<SpriteRenderer>();

        Health = 1;
    }

    protected override void Behaviour()
    {
        try
        {
            if(_state == State.Unwary)
            {
                Normal();
                
            }
            else if(_state == State.Alert)
            {
                Angry();
            }
        }
        catch (System.NullReferenceException e)
        {
            Debug.Log(e);
        }
    }

    void Angry()
    {
        _sp.sprite = _angryPNG;

        try
        {
            float d = Vector3.Distance(PlayerContext.Instance.transform.position, transform.position);
            if (d > _detectionDistance)
            {
                _state = State.Unwary;
                return;
            }
        }
        catch(System.NullReferenceException e)
        {
            Debug.Log(e);
        }

        float w = Whatever();
        transform.localScale = new Vector3(w, 1f, 1f);
        _rb2D.position += new Vector2(w, 0f) * _speed * Time.deltaTime;
    }
    void Normal()
    {
        _sp.sprite = _normalPNG;

        try
        {
            float d = Vector3.Distance(PlayerContext.Instance.transform.position, transform.position);

            if (d < _detectionDistance)
            {
                _state = State.Alert;
                return;
            }

        }
        catch(System.NullReferenceException e)
        {
            Debug.Log(e);
        }
        

        float t = Time.unscaledTime % _unwaryDirChange;
        float w = 0;

        if (t <= _unwaryDirChange / 2f)
        {
            w = Whatever();
        }
        else if (_unwaryDirChange / 2f < t && t <= _unwaryDirChange)
        {
            w = -1 * Whatever();
        }

        transform.localScale = new Vector3(w, 1f, 1f);
    }

    void OnCollisionEnter2D(Collision2D c)
    {
        if(c.collider == PlayerContext.Instance.C2D)
        {
            PlayerContext.Instance.Damage((Vector2) transform.position);
        }    
    }

    float Whatever()
    {
        float p = PlayerContext.Instance.transform.position.x;
        float e = transform.position.x;

        float d = Mathf.Sign(p - e);
        return d;
    }
}