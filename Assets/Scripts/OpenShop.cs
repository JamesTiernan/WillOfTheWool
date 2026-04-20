using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections;

public class OpenShop : MonoBehaviour, IInteractable
{

    [SerializeField] GameObject woolPrefab;
    [SerializeField] private GameObject ShopPanel;
    private CoinManager coinManager;
    int Total;
    [SerializeField] Sprite magnetWool;
    [SerializeField] Sprite fireWool;
    [SerializeField] Sprite stickyWool;
    bool isInteractable;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        coinManager = GameObject.FindGameObjectWithTag("CoinManager").GetComponent<CoinManager>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Interact()
    {
        ShopPanel.SetActive(true);
    }


    public bool IsInteractable()
    {
        return true;
    }

    public void Close()
    {
        ShopPanel.SetActive(false);
    }

    public void BuyWool()
    {
        int Total = coinManager.Coins;

        if(Total > 0)
        {
        GameObject newObject = Instantiate(woolPrefab);
        newObject.transform.position = transform.position;
        coinManager.CoinRemove(1);
        }
    }

        public void MagnetWool()
    {
        int Total = coinManager.Coins;
        if(Total > 0)
        {
        GameObject newObject = Instantiate(woolPrefab);
        newObject.transform.position = transform.position;
        coinManager.CoinRemove(1);
        newObject.GetComponent<SpriteRenderer>().sprite = magnetWool;
        }
    }

     public void StickyWool()
    {
        int Total = coinManager.Coins;
        if(Total > 0)
        {
        GameObject newObject = Instantiate(woolPrefab);
        newObject.transform.position = transform.position;
        coinManager.CoinRemove(1);
        newObject.GetComponent<SpriteRenderer>().sprite = stickyWool;
        }
    }
     public void FireWool()
    {
        int Total = coinManager.Coins;
        if(Total > 0)
        {
        GameObject newObject = Instantiate(woolPrefab);
        newObject.transform.position = transform.position;
        coinManager.CoinRemove(1);
        newObject.GetComponent<SpriteRenderer>().sprite = fireWool;
        }
    }
}
