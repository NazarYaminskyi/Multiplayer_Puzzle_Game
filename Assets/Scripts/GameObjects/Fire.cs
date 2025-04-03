using UnityEngine;

public class Fire : MonoBehaviour
{
    void Update()
    {
        ButtonFire fire = FindObjectOfType<ButtonFire>();
        if(fire.IsOff==true)
        {
            Destroy(gameObject);
            Debug.Log("Destroyed!");
        }
    }
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
