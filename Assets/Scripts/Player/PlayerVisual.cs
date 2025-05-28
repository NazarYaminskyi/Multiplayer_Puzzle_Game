using System;
using UnityEngine;

public class PlayerVisual : MonoBehaviour
{
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;
    private const string IS_RUNNING = "IsRunning";
    private const string ON_GROUND = "OnGround";
    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }
    public void Update()
    {
        _animator.SetBool(IS_RUNNING, Player.Instance.IsRunning());
        _animator.SetBool(ON_GROUND, Player.Instance.OnGround());
        Flip();
    }

    public void Flip()
    {
        if (Player.Instance.moveVector2.x > 0)
        {
            _spriteRenderer.flipX = true;
        }
        else if (Player.Instance.moveVector2.x < 0)
        {
            _spriteRenderer.flipX = false;
        }
    }
}
