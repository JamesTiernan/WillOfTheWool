using System.Globalization;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    [SerializeField] public int Coins{ get; private set; } = 0;
    [SerializeField] private TMP_Text Coin;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        
        Coin.text = Coins.ToString();
    }

    public int CoinAdd(int amount)
    {
        Coins += amount;
        Debug.Log(Coins);
        return Coins;
    }

    public int CoinRemove(int amount)
    {
        Coins -= amount;
        Debug.Log(Coins);
        return Coins;
    }

    public int ReturnCoins()
    {
        return Coins;
    }
}
