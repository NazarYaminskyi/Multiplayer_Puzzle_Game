using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class PlayerPlayModeTests
{
    private GameObject _playerObj;
    private Player _player;
    private Rigidbody2D _rb;

    [UnitySetUp]
    public IEnumerator Setup()
    {
        _playerObj = new GameObject("Player");
        _player = _playerObj.AddComponent<Player>();
        _rb = _playerObj.AddComponent<Rigidbody2D>();
        _playerObj.AddComponent<BoxCollider2D>();

        Player.Instance = _player;

        var groundObj = new GameObject("Ground");
        groundObj.layer = LayerMask.NameToLayer("Ground");
        groundObj.AddComponent<BoxCollider2D>();
        groundObj.transform.position = Vector3.down * 2f;

        yield return null; 
    }

    [UnityTearDown]
    public IEnumerator Teardown()
    {
        Object.Destroy(_playerObj);
        Object.Destroy(GameObject.Find("Ground"));
        yield return null;
    }

    [UnityTest]
    public IEnumerator Player_FallsAndLandsOnGround()
    {
        _playerObj.transform.position = Vector3.up * 2f;

        yield return new WaitForSeconds(0f);

        Assert.IsFalse(_player.OnGround());
    }

    [UnityTest]
    public IEnumerator Player_Jump_ChangesVelocity()
    {
        _player._onGround = true;

        _player.Jump();

        yield return null;

        Assert.Less(_rb.linearVelocity.y, 0f);
    }
}
public class StartLevelFlying1Tests
{
    private GameObject _flyingObj;
    private StartLevelFlying1 _flying;

    [UnitySetUp]
    public IEnumerator Setup()
    {
        _flyingObj = new GameObject("FlyingPlatform");
        _flying = _flyingObj.AddComponent<StartLevelFlying1>();
        _flyingObj.AddComponent<BoxCollider2D>().isTrigger = true;
        _flyingObj.AddComponent<Rigidbody2D>(); 
        yield return null;
    }

    [UnityTest]
    public IEnumerator FlyingPlatform_MovesUpAndDown()
    {
        Vector2 initialPosition = _flyingObj.transform.position;
        yield return new WaitForSeconds(1f);
        Assert.AreNotEqual(initialPosition, _flyingObj.transform.position);
    }
}
public class BowTrapTests
{
    private GameObject _bowTrapObj;
    private BowTrap _bowTrap;
    private GameObject _arrowPrefab;
    private GameObject _playerObj;
    private Player _player;

    [UnitySetUp]
    public IEnumerator Setup()
    {
        _playerObj = new GameObject("Player");
        _player = _playerObj.AddComponent<Player>();
        _playerObj.AddComponent<Rigidbody2D>();
        Player.Instance = _player; 

        _bowTrapObj = new GameObject("BowTrap");
        _bowTrap = _bowTrapObj.AddComponent<BowTrap>();
        _bowTrap.firePoint = _bowTrapObj.transform;

        _arrowPrefab = new GameObject("ArrowPrefab");
        _arrowPrefab.AddComponent<Arrow>().speed = 5f;
        _arrowPrefab.AddComponent<Rigidbody2D>();
        _bowTrap.arrowPrefab = _arrowPrefab;

        yield return null; 
    }

    [UnityTest]
    public IEnumerator BowTrap_FiresArrow()
    {
        _bowTrap.FireArrow();
        yield return null; 

        Arrow arrow = Object.FindObjectOfType<Arrow>();
        Assert.IsNotNull(arrow, "������ �� ���� �������");
        Assert.AreNotEqual(Vector2.zero, arrow.GetComponent<Rigidbody2D>().linearVelocity);
    }

    [UnityTearDown]
    public IEnumerator Teardown()
    {
        Object.Destroy(_bowTrapObj);
        Object.Destroy(_arrowPrefab);
        Object.Destroy(_playerObj);
        yield return null;
    }
}



