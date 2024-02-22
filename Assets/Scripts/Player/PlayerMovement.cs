
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField, Range(0.1f, 5f)] private float _limitValueX = 1.2f;

    [Header("Jump")]
    [SerializeField, Range(0.08f, 0.35f)] private float _maxTimeToJump = 0.11f;
    [SerializeField, Range(1f, 100f)] private float _jumpForce = 5f;
    [SerializeField, Range(0.1f, 25f)] private float _gravityScale = 1f;
    private float _currentTimeToJump = 0f;
    private Rigidbody _rb;
    private Animator _animator;
    
    //? Scripts references
    private PlayerColliders _playerColliders;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
        _playerColliders = GetComponent<PlayerColliders>();
    }
    void Update()
    {
        // If touching the screen
        if (Input.touchCount > 0)
        {
            _currentTimeToJump += Time.deltaTime;
    
            if (Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                MovePlayer();
            }
            
        }else if (_currentTimeToJump > 0 && _currentTimeToJump <= _maxTimeToJump && _playerColliders.IsGrounded())
        {
            // If player touch the screen for a short time and is grounded
            Jump();
            _currentTimeToJump = 0;

        }else if(_currentTimeToJump > _maxTimeToJump || !_playerColliders.IsGrounded())
        {
            _currentTimeToJump = 0;
        }

    }

    void FixedUpdate ()
    {

        // Apply gravity
        Vector3 _gravity = GameManager.GlobalGravity * _gravityScale * Vector3.up;
        _rb.AddForce(_gravity, ForceMode.Acceleration);
    }

    
    void MovePlayer()
    {
        float halfScreen = Screen.width / 2;
        float xPos = (Input.GetTouch(0).position.x - halfScreen) / Screen.width;

        // Limit the value of the player's position
        float finalXPos = Mathf.Clamp(xPos * _limitValueX, -_limitValueX+2f, _limitValueX);

        transform.position = new Vector3(finalXPos, transform.position.y, transform.position.z);
    }

    void Jump()
    {
        // Add force to jump
        GetComponent<Rigidbody>().AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);

        //Play jump animation
        _animator.SetTrigger("Jump");

    }

}
