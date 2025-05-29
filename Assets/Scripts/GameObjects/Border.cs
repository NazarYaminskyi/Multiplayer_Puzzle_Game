using UnityEngine;

public class Border : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player2")
        {
            Player player = other.GetComponentInParent<Player>();
            player.Death();
            Debug.Log("Destroyed!");
        }
    }
}
