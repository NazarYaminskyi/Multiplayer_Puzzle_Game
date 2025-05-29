using UnityEngine;

public class Fire : MonoBehaviour
{
    void Update()
    {
        //ButtonFire fire = FindObjectOfType<ButtonFire>();
        if(ButtonFire.IsOff==true)
        {
            Destroy(gameObject);
            //Debug.Log("Destroyed!");
        }
    }
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
