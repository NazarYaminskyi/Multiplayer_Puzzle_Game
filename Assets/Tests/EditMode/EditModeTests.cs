using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;

public class PlayerTests
{
    private GameObject _playerObj;
    private Player _player;
    private Rigidbody2D _rb;

    [SetUp]
    public void Setup()
    {
        _playerObj = new GameObject("Player");
        _rb = _playerObj.AddComponent<Rigidbody2D>();
        _playerObj.AddComponent<BoxCollider2D>();
        _player = _playerObj.AddComponent<Player>();

        var groundCheckObj = new GameObject("GroundCheck");
        groundCheckObj.transform.SetParent(_playerObj.transform);
        groundCheckObj.transform.position = Vector3.zero;
        _player._groundCheck = groundCheckObj.transform;
    }

    [TearDown]
    public void Teardown()
    {
        Object.DestroyImmediate(_playerObj);
    }

    [Test]
    public void Player_IsRunning_WhenMoving()
    {
        _player.moveVector2.x = 1f;
        Assert.IsTrue(_player.IsRunning());

        _player.moveVector2.x = 0f;
        Assert.IsFalse(_player.IsRunning());
    }

    [Test]
    public void Player_OnGround_WhenOverlapCircleTrue()
    {
        var groundObj = new GameObject("Ground");
        groundObj.layer = LayerMask.NameToLayer("Ground");
        groundObj.transform.position = _player._groundCheck.position;
        groundObj.AddComponent<BoxCollider2D>();

        _player.CheckingGround();

        Assert.IsFalse(_player.OnGround());

        Object.DestroyImmediate(groundObj);
    }

    [Test]
    public void Player_Jump_SetsVerticalVelocity()
    {
        _player._onGround = true; 
        _player.Jump(); 
        Assert.AreNotEqual(0.0001f, _rb.linearVelocity.y);
    }
}
public class PlayerVisualTests
{
    private GameObject _playerVisualObj;
    private PlayerVisual _playerVisual;
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;

    [SetUp]
    public void Setup()
    {
        _playerVisualObj = new GameObject("PlayerVisual");
        _animator = _playerVisualObj.AddComponent<Animator>();
        _spriteRenderer = _playerVisualObj.AddComponent<SpriteRenderer>();
        _playerVisual = _playerVisualObj.AddComponent<PlayerVisual>();


        var playerObj = new GameObject("Player");
        var player = playerObj.AddComponent<Player>();
        player.moveVector2 = Vector2.zero;
    }

    [TearDown]
    public void Teardown()
    {
        Object.DestroyImmediate(_playerVisualObj);
        Object.DestroyImmediate(Player.Instance.gameObject);
    }

    [Test]
    public void PlayerVisual_FlipX_WhenMovingRight()
    {
        Player.Instance.moveVector2.x = 1f;
        _playerVisual.Flip();
        Assert.IsTrue(_spriteRenderer.flipX);

        Player.Instance.moveVector2.x = -1f;
        _playerVisual.Flip();
        Assert.IsFalse(_spriteRenderer.flipX);
    }

    [Test]
    public void PlayerVisual_AnimatorParameters_SetCorrectly()
    {
        Player.Instance.moveVector2.x = 0f; 
        Player.Instance._onGround = false; 

        _playerVisual.Update();

        Assert.IsFalse(_animator.GetBool("IsRunning"));
        Assert.IsFalse(_animator.GetBool("OnGround"));
    }
}
