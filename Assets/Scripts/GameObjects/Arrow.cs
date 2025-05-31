using UnityEngine;
using System.Collections;
public class Arrow : MonoBehaviour
{
    public float speed = 5f;
    public float lifeTime = 5f;
    private Rigidbody2D rb;

    public void Fire(Vector2 direction)
    {
        rb = GetComponent<Rigidbody2D>();
        rb.linearVelocity = direction.normalized * speed;
        Destroy(gameObject, lifeTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Player player = other.GetComponentInParent<Player>(); 
        if (player != null)
        {
            player.Death();
        }

        Destroy(gameObject); 
    }

}
