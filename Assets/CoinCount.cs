using UnityEngine;
using UnityEngine.UI;
public class CoinCount : MonoBehaviour
{
    public SpriteRenderer CoinImage;
    public Sprite[] Numberofsprites;
    public void UpdateUI(int coinCount)
    {
        CoinImage.sprite = Numberofsprites[coinCount];
    }
}
// CoinCount action = other.transform.GetComponent<CoinCount>();
//             coinCount++;
//             action.UpdateUI(coinCount);
//public static int coinCount = 0;
