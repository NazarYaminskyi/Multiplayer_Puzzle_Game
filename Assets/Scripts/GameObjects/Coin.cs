using UnityEngine;

public class Coin : MonoBehaviour
{
    public static int coinCount = -1;
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Об'єкт торкнувся: " + other.gameObject.name);
        if(other.tag == "Player2")
        {
            //CoinCount action = other.GetComponentInParent<CoinCount>();
            CoinCount action = FindObjectOfType<CoinCount>();
            coinCount++;
            Debug.Log($"{coinCount} - number now");
            Destroy(gameObject);
            action.UpdateUI(coinCount);
            Debug.Log("Dissapeared");
        }
    }
}
