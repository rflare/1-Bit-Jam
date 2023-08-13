using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerContext : MonoBehaviour
{
    //private properties
    [SerializeField] private float _speed;

    private PlayerControls _input;
    private Rigidbody2D _rb2D;

    //public properties, getters and setters
    public static PlayerContext Instance {get; private set;}

    public bool IsGrounded {get; set;}
    //Methods
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
        if(Instance != null && Instance != this)
        {
            Destroy(this);
        }
        _input = new PlayerControls();
        _rb2D = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
    }
    void Update()
    {
        HandleMovement();
    }
    void HandleMovement()
    {
        float left = _input.main.Left.ReadValue<float>();
        float right = _input.main.Right.ReadValue<float>();

        Vector2 move = new Vector2(right - left, 0) * _speed;

        _rb2D.position += move * Time.deltaTime;
    }
}
