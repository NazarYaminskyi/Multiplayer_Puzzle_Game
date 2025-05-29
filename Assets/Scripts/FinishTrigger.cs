using UnityEngine;

public class FinishTrigger2D : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            FindObjectOfType<LevelTimer>().StopTimer();
        }
    }
}