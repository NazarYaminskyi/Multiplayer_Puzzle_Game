using UnityEngine;

public class Trampoline : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float high = 0.1f;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player2")
        {
            PlayerController2DD player = other.transform.GetComponent<PlayerController2DD>();
            player.TrampolineJump(high);
            Debug.Log("Jumped");
        }
    }
}
