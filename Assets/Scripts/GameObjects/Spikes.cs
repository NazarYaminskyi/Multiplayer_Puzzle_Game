using UnityEngine;

public class Spikes : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player2")
        {
            PlayerController2DD player = other.transform.GetComponent<PlayerController2DD>();
            player.Death();
            Debug.Log("Destroyed!");
        }
    }
}
