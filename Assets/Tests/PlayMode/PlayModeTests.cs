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
        _rb = _playerObj.AddComponent<Rigidbody2D>();
        _player = _playerObj.AddComponent<Player>();
        _playerObj.AddComponent<BoxCollider2D>();

        var groundCheck = new GameObject("GroundCheck").transform;
        groundCheck.SetParent(_playerObj.transform);
        groundCheck.localPosition = Vector3.down * 0.5f;
        _player._groundCheck = groundCheck;

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


