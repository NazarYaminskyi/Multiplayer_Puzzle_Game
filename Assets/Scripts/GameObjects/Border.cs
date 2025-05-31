using UnityEngine;

public class Border : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player2" || other.tag == "Player")
        {
            Player player = other.GetComponentInParent<Player>();
            player.Death();
            Debug.Log("Destroyed!");
        }
    }
}
