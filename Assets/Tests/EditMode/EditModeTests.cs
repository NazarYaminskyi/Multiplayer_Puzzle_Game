using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

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
        var playerObj = new GameObject("Player");
        Player.Instance = playerObj.AddComponent<Player>();
        Player.Instance.moveVector2 = Vector2.zero;

        _playerVisualObj = new GameObject("PlayerVisual");
        _playerVisual = _playerVisualObj.AddComponent<PlayerVisual>();
        _animator = _playerVisualObj.AddComponent<Animator>();
        _spriteRenderer = _playerVisualObj.AddComponent<SpriteRenderer>();
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
public class TrampolineTests
{
    private GameObject _trampolineObj;
    private Trampoline _trampoline;
    private GameObject _playerObj;
    private Player _player;

    [SetUp]
    public void Setup()
    {
        _trampolineObj = new GameObject("Trampoline");
        _trampoline = _trampolineObj.AddComponent<Trampoline>();
        _trampolineObj.AddComponent<BoxCollider2D>().isTrigger = true;

        _playerObj.AddComponent<Rigidbody2D>();
        _playerObj = new GameObject("Player");
        _player = _playerObj.AddComponent<Player>();
        _playerObj.tag = "Player2";
        _playerObj.AddComponent<BoxCollider2D>().isTrigger = true;
    }

    [Test]
    public void Trampoline_TriggersJump_WhenPlayerCollides()
    {
        ButtonTrampoline.IsOff = true;

        _playerObj.AddComponent<Rigidbody2D>();
        _playerObj.tag = "Player2";

        _trampoline.OnTriggerEnter2D(_playerObj.GetComponent<Collider2D>());

        Assert.AreNotEqual(0f, _playerObj.GetComponent<Rigidbody2D>().linearVelocity.y);
    }
}
public class SpikesTests
{
    private GameObject _spikesObj;
    private Spikes _spikes;
    private GameObject _playerObj;
    private Player _player;

    [SetUp]
    public void Setup()
    {
        _spikesObj = new GameObject("Spikes");
        _spikes = _spikesObj.AddComponent<Spikes>();
        _spikesObj.AddComponent<BoxCollider2D>().isTrigger = true;

        _playerObj = new GameObject("Player");
        _player = _playerObj.AddComponent<Player>();
        _playerObj.tag = "Player2";
        _playerObj.AddComponent<BoxCollider2D>().isTrigger = true;
    }

    [Test]
    public void Spikes_KillsPlayer_OnCollision()
    {
        bool deathCalled = true;
        _spikes.OnTriggerEnter2D(_playerObj.GetComponent<Collider2D>());
        Assert.IsTrue(deathCalled);
    }
}
public class LeverTests
{
    private GameObject _leverObj;
    private Lever _lever;
    private GameObject _flyingObj;
    private Flying1 _flying;

    [SetUp]
    public void Setup()
    {
        _leverObj = new GameObject("Lever");
        _lever = _leverObj.AddComponent<Lever>();
        _leverObj.AddComponent<Rigidbody2D>();

        _flyingObj = new GameObject("FlyingPlatform");
        _flying = _flyingObj.AddComponent<Flying1>();
    }

    [Test]
    public void Lever_UpdatesXPosition()
    {
        _leverObj.transform.position = new Vector3(57f, 0, 0);
        _lever.FixedUpdate();
        Assert.AreEqual(57f, _lever.xPosition);
    }
}
public class FireTests
{
    private GameObject _fireObj;
    private Fire _fire;
    private GameObject _playerObj;
    private Player _player;

    [SetUp]
    public void Setup()
    {
        _fireObj = new GameObject("Fire");
        _fire = _fireObj.AddComponent<Fire>();
        _fireObj.AddComponent<BoxCollider2D>().isTrigger = true;

        _playerObj = new GameObject("Player");
        _player = _playerObj.AddComponent<Player>();
        _playerObj.tag = "Player2";
        _playerObj.AddComponent<BoxCollider2D>().isTrigger = true;
    }

    [Test]
    public void Fire_KillsPlayer_OnCollision()
    {
        bool deathCalled = true;
        _fire.OnTriggerEnter2D(_playerObj.GetComponent<Collider2D>());
        Assert.IsTrue(deathCalled);
    }
}
public class CoinTests
{
    private GameObject _coinObj;
    private Coin _coin;
    private GameObject _playerVisualObj;
    private GameObject _coinCountObj;
    private CoinCount _coinCount;

    [SetUp]
    public void Setup()
    {
        _coinObj = new GameObject("Coin");
        _coin = _coinObj.AddComponent<Coin>();
        _coinObj.AddComponent<BoxCollider2D>().isTrigger = true;

        _playerVisualObj = new GameObject("PlayerVisual");
        _playerVisualObj.AddComponent<BoxCollider2D>().isTrigger = true;

        _coinCountObj = new GameObject("CoinCount");
        _coinCount = _coinCountObj.AddComponent<CoinCount>();
        _coinCount.CoinImage = _coinCountObj.AddComponent<SpriteRenderer>();
        _coinCount.Numberofsprites = new Sprite[10];
    }

    [Test]
    public void Coin_IncrementsCount_WhenCollected()
    {
        int initialCount = Coin.coinCount;
        _coin.OnTriggerEnter2D(_playerVisualObj.GetComponent<Collider2D>());
        Assert.AreEqual(initialCount + 1, Coin.coinCount);
    }
}
public class BorderTests
{
    private GameObject _borderObj;
    private Border _border;
    private GameObject _playerObj;
    private Player _player;

    [SetUp]
    public void Setup()
    {
        _borderObj = new GameObject("Border");
        _border = _borderObj.AddComponent<Border>();
        _borderObj.AddComponent<BoxCollider2D>().isTrigger = true;

        _playerObj = new GameObject("Player");
        _player = _playerObj.AddComponent<Player>();
        _playerObj.tag = "Player2";
        _playerObj.AddComponent<BoxCollider2D>().isTrigger = true;
    }

    [Test]
    public void Border_KillsPlayer_OnCollision()
    {
        bool deathCalled = true;
        _border.OnTriggerEnter2D(_playerObj.GetComponent<Collider2D>());
        Assert.IsTrue(deathCalled);
    }
}

