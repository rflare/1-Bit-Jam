using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerContext : MonoBehaviour
{
    //private properties
    [SerializeField] private float _speed;

    [SerializeField] private float _debugLeft;
    [SerializeField] private float _debugRight;

    private PlayerControls _input;
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
        _input = new PlayerControls();

        _input.main.Left.performed += ctx => Debug.Log("hello");
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
        _debugLeft = _input.main.Left.ReadValue<float>();
        _debugRight = _input.main.Right.ReadValue<float>();
    }
}
