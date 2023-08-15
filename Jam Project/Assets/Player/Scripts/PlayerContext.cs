using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerContext : MonoBehaviour
{
    //Constants
    public static readonly Vector3 RIGHT_DIR = new Vector3(-1, 1, 1);
    public static readonly Vector3 LEFT_DIR = new Vector3(1, 1, 1);
    //private properties
    List<IPlayerAttackObserver> _attackObservers = new List<IPlayerAttackObserver>();

    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;


    private PlayerControls _input;
    private Rigidbody2D _rb2D;
    private Collider2D _c2D;
    private SpriteRenderer _spriteRenderer;


    //public properties, getters and setters
    public PlayerBaseState CurrentState;
    public static PlayerContext Instance {get; private set;}

    [field: SerializeField] public bool IsGrounded {get; set;}
    [field: SerializeField] public Sprite LightSprite {get; private set;}
    [field: SerializeField] public Sprite DarkSprite {get; private set;}
    //Private Methods
    void OnEnable()
    {
        _input.Enable();
    }
    void OnDisable()
    {
        _input.Disable();
    }
    void Awake()
    {
        Debug.Log("Boo");
        if(Instance != null && Instance != this)
        {
            Destroy(this);
        }
        Instance = this;

        _input = new PlayerControls();
        _rb2D = GetComponent<Rigidbody2D>();
        _c2D = GetComponent<Collider2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void Start()
    {
        if (IsTouchingBlack()) CurrentState = new PlayerDarkState();
        else CurrentState = new PlayerLightState();

        CurrentState.Start(this);
    }
    void Update()
    {
        CurrentState.Update(this);
        CurrentState.CheckSwitchStates(this);
    }

    //Public Methods
    public void HandleMovement()
    {
        float left = _input.main.Left.ReadValue<float>();
        float right = _input.main.Right.ReadValue<float>();

        Vector2 move = new Vector2(right - left, 0) * _speed;

        _rb2D.position += move * Time.deltaTime;
    }
    public void HandleJump()
    {
        if(_input.main.Jump.triggered)
        {
            float gravity = Physics2D.gravity.y * _rb2D.gravityScale;
            float forceUp = Mathf.Sqrt(-2f * _jumpForce * gravity);

            _rb2D.AddForce(Vector2.up * forceUp, ForceMode2D.Impulse);
        }
    }
    public void HandleBite()
    {
        if (_input.main.Attack1.triggered)
        {
            foreach(var observer in _attackObservers)
            {
                observer.NotifyAttack();
            }
        }
    }
    public void HandleDirection()
    {
        if (_input.main.Left.triggered) transform.localScale = LEFT_DIR;
        if (_input.main.Right.triggered) transform.localScale = RIGHT_DIR;
    }
    public bool IsTouchingBlack()
    {
        return _c2D.IsTouchingLayers(64);
    }
    public bool IsTouchingWhite()
    {
        return _c2D.IsTouchingLayers(128);
    }
    public void ChangeSprite(Sprite s)
    {
        _spriteRenderer.sprite = s;
    }

    public void AddAttackObserver(IPlayerAttackObserver observer)
    {
        _attackObservers.Add(observer);
    }
    public void RemoveAttackObserver(IPlayerAttackObserver observer)
    {
        _attackObservers.Remove(observer);
    }
}
