using System;
using UnityEngine;
[SelectionBase]
public class PlayerDown : MonoBehaviour
{
    public static PlayerDown Instance { get; private set; }
    [SerializeField] private float _speed = 10f;
    [SerializeField] private float jumpForce = 10f;
    [SerializeField] private KeyCode jumpKey = KeyCode.UpArrow;
    [SerializeField] private KeyCode leftKey = KeyCode.LeftArrow;
    [SerializeField] private KeyCode rightKey = KeyCode.RightArrow;

    public Vector2 moveVector2;
    private Rigidbody2D rb;
    private bool _isRunning;
    private float _minRunningSpeed = 0.01f;
    private bool _onGround = false;

    [SerializeField] private Transform _groundCheck;
    [SerializeField] private float _checkRadius = 0.1f;
    [SerializeField] private LayerMask _ground;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Walk();
        Jump();
        CheckingGround();
    }

    public bool IsRunning()
    {
        return Mathf.Abs(moveVector2.x) > _minRunningSpeed;
    }

    public bool OnGround()
    {
        return _onGround;
    }

    private void Walk()
    {
        float moveInput = 0;

        if (Input.GetKey(leftKey)) moveInput -= 1;
        if (Input.GetKey(rightKey)) moveInput += 1;

        moveVector2 = new Vector2(moveInput * _speed, rb.linearVelocity.y);
        rb.linearVelocity = moveVector2;
    }

    private void Jump()
    {
        if (Input.GetKeyDown(jumpKey) && _onGround)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }
    }

    private void CheckingGround()
    {
        _onGround = Physics2D.OverlapCircle(_groundCheck.position, _checkRadius, _ground);
    }

    public void Death()
    {
        transform.position = new Vector2(20.464f, -6.656f);
    }

    public void TrampolineJump(float high)
    {
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, high);
    }
}
