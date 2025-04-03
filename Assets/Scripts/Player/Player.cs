using System;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading;
using UnityEngine;



[SelectionBase]
public class Player : MonoBehaviour
{
    public static Player Instance { get; private set; }
    [SerializeField] private float _speed = 10f;
    [SerializeField] private float jumpForse = 10f;
    public Vector2 moveVector2;
    private Rigidbody2D rb;
    private bool _isRunning;
    private float _minRunningSpeed = 0.01f;
    private bool isGrounded; // Перевірка, чи персонаж на землі
    private void Awake()
    {
        Instance = this;
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        Walk();
        Jump();
        CheckingGround();
    }
    private void FixedUpdate()
    {
        //Walk();
        //Jump();
        //CheckingGround();
    }
    public bool IsRunning()
    {
        if (Math.Abs(moveVector2.x) > _minRunningSpeed)
        {
            _isRunning = true;
        }
        else
        {
            _isRunning = false;
        }
        return _isRunning;
    }
    public bool OnGround()
    {
        return _onGround;
    }
    private void Walk()
    {
        moveVector2.x = Input.GetAxis("Horizontal") * _speed;
        //rb.linearVelocity = moveVector2;
        float moveInput = Input.GetAxisRaw("Horizontal"); 
        rb.linearVelocity = new Vector2(moveInput * _speed, rb.linearVelocity.y);
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _onGround)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForse);
        }

    }

    [SerializeField] private bool _onGround = false;
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private float _checkRadius = 0.1f;
    [SerializeField] private LayerMask _ground;
    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.CompareTag("Ground")) // Перевіряємо, чи доторкнулися до землі
    //    {
    //        _onGround = true;
    //        Debug.Log("True");
    //    }

    //}

    //private void OnCollisionExit2D(Collision2D collision)
    //{
    //    if (collision.gameObject.CompareTag("Ground")) // Перевіряємо, чи персонаж покинув землю
    //    {
    //        _onGround = false;

    //    }
    //}
    private void CheckingGround()
    {
        _onGround = Physics2D.OverlapCircle(_groundCheck.position, _checkRadius, _ground);

    }

}
