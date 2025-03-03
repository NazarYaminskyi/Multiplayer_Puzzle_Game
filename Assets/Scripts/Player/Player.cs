using System;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;



[SelectionBase]
public class Player : MonoBehaviour
{
    public static Player Instance { get; private set; }
    [SerializeField] private float _speed = 10f;
    [SerializeField] private float jumpForse = 5000f;
    public Vector2 moveVector2;
    private Rigidbody2D rb;
    private bool _isRunning;
    private float _minRunningSpeed = 0.1f;
   
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
        rb.linearVelocity = moveVector2;
    }

    //private bool _jumpControl;
    //private float _jumpTime = 0;
    //[SerializeField] private float jumpControlTime = 0.7f;
    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _onGround)
        {
            //rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForse);
            rb.AddForce(Vector2.up * jumpForse);
        }
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    if (_onGround)
        //    {
        //        _jumpControl = true;
        //    }
        //}
        //else
        //{
        //    _jumpControl = false;
        //}
        //if (_jumpControl)
        //{
        //    if ((_jumpTime += Time.deltaTime) < jumpControlTime)
        //    {
        //        rb.AddForce(Vector2.up * jumpForse/(_jumpTime*10));
        //    }
        //}
        //else
        //{
        //    _jumpTime = 0;
        //}
    }

    [SerializeField] private bool _onGround = false;
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private float _checkRadius = 0.1f;
    [SerializeField] private LayerMask _ground;
    private void CheckingGround()
    {
        _onGround = Physics2D.OverlapCircle(_groundCheck.position, _checkRadius, _ground);
        Debug.Log("On Ground: " + _onGround);
    }

}
