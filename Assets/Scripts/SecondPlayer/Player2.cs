using UnityEngine;

using UnityEngine;
using System;

public class PlayerController2DD : MonoBehaviour
{
    public float moveSpeed = 5f; // Швидкість руху
    public float jumpForce = 10f; // Сила стрибка
    private bool isGrounded; // Перевірка, чи персонаж на землі
    private bool _isRunning; // Перевірка, чи персонаж біжить
    private float _minRunningSpeed = 0.001f; // Мінімальна швидкість для бігу
    public Vector2 moveVector2;
    public static PlayerController2DD Instance { get; private set; }

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Instance = this;
    }

    void Update()
    {
        Move();
        Jump();
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
        return isGrounded;
    }
    void Move()
    {
        float moveInput = Input.GetAxisRaw("Horizontal"); // Отримуємо ввід (A/D або стрілки)
        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);
        //moveVector2.x = Input.GetAxis("Horizontal") * moveSpeed;
        //rb.linearVelocity = moveVector2;
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce); // Додаємо силу стрибка
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground")) // Перевіряємо, чи доторкнулися до землі
        {
            isGrounded = true;
            Debug.Log("True");
        }
        
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground")) // Перевіряємо, чи персонаж покинув землю
        {
            isGrounded = false;
            
        }
        
    }
    public void Death()
    {
        transform.position = new Vector2(20.464f, 7.656f);
    }
    public void TrampolineJump(float high)
    {
       rb.linearVelocity = new Vector2(rb.linearVelocity.x, high);
    }
}
