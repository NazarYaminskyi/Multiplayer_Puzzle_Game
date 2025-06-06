using UnityEngine;

[SelectionBase]
public class Player : MonoBehaviour
{
    public static Player Instance { get;  set; }
    [SerializeField] private float _speed = 10f;
    [SerializeField] private float jumpForce = 10f;
    [SerializeField] private KeyCode jumpKey = KeyCode.Space;
    [SerializeField] private KeyCode leftKey = KeyCode.A;
    [SerializeField] private KeyCode rightKey = KeyCode.D;
    public Vector2 Coordinates;

    public Vector2 moveVector2;
    private Rigidbody2D rb;
    private bool _isRunning;
    private float _minRunningSpeed = 0.01f;

    private bool isGrounded;

    public bool _onGround = false;

    [SerializeField] public Transform _groundCheck;
    [SerializeField] private float _checkRadius = 0.1f;
    [SerializeField] private LayerMask _ground;
    private void Awake()
    {
        Instance = this;
        rb = GetComponent<Rigidbody2D>();
    }

    public void Update()
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

    public void Walk()
    {
        float moveInput = 0;

        if (Input.GetKey(leftKey)) moveInput -= 1;
        if (Input.GetKey(rightKey)) moveInput += 1;

        moveVector2 = new Vector2(moveInput * _speed, rb.linearVelocity.y);
        rb.linearVelocity = moveVector2;
    }

    public void Jump()
    {
        if (Input.GetKeyDown(jumpKey) && _onGround)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }
    }
    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.CompareTag("Ground")) // ����������, �� ������������ �� ����
    //    {
    //        _onGround = true;
    //        Debug.Log("True");
    //    }

    //}

    //private void OnCollisionExit2D(Collision2D collision)
    //{
    //    if (collision.gameObject.CompareTag("Ground")) // ����������, �� �������� ������� �����
    //    {
    //        _onGround = false;

    //    }
    //}
    public void CheckingGround()
    {
        _onGround = Physics2D.OverlapCircle(_groundCheck.position, _checkRadius, _ground);
    }

    public void Death()
    {
        transform.position = new Vector2(Coordinates.x, Coordinates.y);
    }

    public void TrampolineJump(float high)
    {
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, high);
    }
}
