using UnityEngine;

public class PlayerHandleGrounded : MonoBehaviour
{
    //Private Properties
    private BoxCollider2D _bc2D;
    //Private Methods
    void Awake()
    {
        _bc2D = GetComponent<BoxCollider2D>();
    }
    void Update()
    {
        PlayerContext.Instance.IsGrounded = _bc2D.IsTouchingLayers(1);
    }
}