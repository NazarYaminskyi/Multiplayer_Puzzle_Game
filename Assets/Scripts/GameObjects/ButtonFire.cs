using UnityEngine;

public class ButtonFire : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public bool IsOff = false;

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player2")
        {
            IsOff=true;
            Debug.Log("Turned off!");
        }
    }
}
