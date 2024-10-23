using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{

    //static PlayerController instance:
    public InputMap PlayerInputMap;
    [SerializeField] private bool _isRat = false;
    private InputAction Move;

    private Rigidbody2D _playerRb;
    private Collider2D _collider;
    private Transform _transform;

    private Vector2 _moveDirection = Vector2.zero;
    [SerializeField] private float _originalMoveSpeed;


    private void Awake()
    {
        PlayerInputMap = new InputMap();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

   

    private void OnEnable()
    {
        if (_isRat) Move = PlayerInputMap.Rat_Player.Move;
        if (!_isRat) Move =  PlayerInputMap.Spider_Player.Move;
        Move.Enable();
    }

    private void OnDisable()
    {
        Move.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        _moveDirection = Move.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        if (_moveDirection.x > -0.3f && _moveDirection.x < 0.3f) _moveDirection.x = 0f;
        if (_moveDirection.y > -0.3f && _moveDirection.y < 0.3f) _moveDirection.y = 0f;

        _playerRb.linearVelocity = new Vector2(_moveDirection.x * _originalMoveSpeed,
                                                _moveDirection.y * _originalMoveSpeed);
    }
}
