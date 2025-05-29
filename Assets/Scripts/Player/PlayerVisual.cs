using System;
using UnityEngine;


public class PlayerVisual : MonoBehaviour

// public class PlayerVsual : MonoBehaviour
// {
//     private Animator _animator;
//     private SpriteRenderer _spriteRenderer;
//     private const string IS_RUNNING = "IsRunning";
//     private const string ON_GROUND = "OnGround";
//     private void Awake()
//     {
//         _animator = GetComponent<Animator>();
//         _spriteRenderer = GetComponent<SpriteRenderer>();
//     }
//     private void Update()
//     {
//         _animator.SetBool(IS_RUNNING, Player.Instance.IsRunning());
//         _animator.SetBool(ON_GROUND, Player.Instance.OnGround());
//         Flip();
//     }
//
//     private void Flip()
//     {
//         if (Player.Instance.moveVector2.x > 0)
//         {
//             _spriteRenderer.flipX = true;
//         }
//         else if (Player.Instance.moveVector2.x < 0)
//         {
//             _spriteRenderer.flipX = false;
//         }
//     }
// }
public class PlayerVsual : MonoBehaviour
{
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;
    private Player _player;

    private const string IS_RUNNING = "IsRunning";
    private const string ON_GROUND = "OnGround";

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _player = GetComponentInParent<Player>(); // Або GetComponent, якщо на тому ж об'єкті
    }  
    public void Update()
    {
        _animator.SetBool(IS_RUNNING, _player.IsRunning());
        _animator.SetBool(ON_GROUND, _player.OnGround());
        Flip();
    }

    public void Flip()
    {
        if (_player.moveVector2.x > 0)
        {
            _spriteRenderer.flipX = true;
        }
        else if (_player.moveVector2.x < 0)
        {
            _spriteRenderer.flipX = false;
        }
    }
}
