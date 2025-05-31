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
