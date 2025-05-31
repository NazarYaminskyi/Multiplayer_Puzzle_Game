using UnityEngine;

public class Spikes : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Об'єкт торкнувся: " + other.gameObject.name);
        if(other.tag == "Player2")
        {
            Player player = other.GetComponentInParent<Player>();
            player.Death();
            Debug.Log("Destroyed!");
        }
    }
}
