using UnityEngine;

public class Border : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    //public PlayerController2DD player;
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Player2 player = 
        
        if(other.tag == "Player2")
        {
            PlayerController2DD player = other.transform.GetComponent<PlayerController2DD>();
            player.Death();
            Debug.Log("Destroyed!");
        }
    }
}
