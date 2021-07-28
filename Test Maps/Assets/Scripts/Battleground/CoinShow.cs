using TMPro;
using UnityEngine;

public class CoinShow : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI count;
    [SerializeField] private CoinMainer coins;

    void FixedUpdate()
    {
        count.text = "Coins: " + coins.coinCount;
    }
}
