using UnityEngine;

public class CoinPickup : MonoBehaviour
{

    CoinManager coinManager;
    private void Start()
    {
        coinManager = GameObject.FindGameObjectWithTag("CoinManager").GetComponent<CoinManager>();

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            
            coinManager.CoinAdd(1);
            Debug.Log("Coin Added");
            Destroy(gameObject);
        }
    }

}
