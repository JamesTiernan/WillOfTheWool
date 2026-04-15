using System.Globalization;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    [SerializeField] public int Coins = 0;
    [SerializeField] private TMP_Text Coin;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(Coins);
        Coin.text = Coins.ToString();
    }

    public int CoinAdd(int amount)
    {
        Coins += amount;
        Debug.Log(Coins);
        return Coins;
    }
}
