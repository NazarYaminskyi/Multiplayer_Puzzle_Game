using UnityEngine;

public class Trampoline : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float high = 0.1f;
    public void OnTriggerEnter2D(Collider2D other)
    {
        //ButtonFire fire = FindObjectOfType<ButtonFire>();
        if(other.tag == "Player2" && ButtonTrampoline.IsOff)
        {
            Player player = other.GetComponentInParent<Player>();
            player.TrampolineJump(high);
            Debug.Log("Jumped");
        }
    }
}
