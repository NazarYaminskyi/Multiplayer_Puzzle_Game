using UnityEngine;

public class Fire : MonoBehaviour
{
    void Update()
    {
        if(ButtonFire.IsOff==true)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player2" || other.tag == "Player")
        {
            Player player = other.GetComponentInParent<Player>();
            player.Death();
            Debug.Log("Destroyed!");
        }
    }
}
