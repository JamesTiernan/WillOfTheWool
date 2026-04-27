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
        
    }

    // Update is called once per frame
    void Update()
    {
        if(coinManager == null)
        coinManager = GameObject.FindGameObjectWithTag("CoinManager").GetComponent<CoinManager>();
    }

    public void Interact()
    {
        ShopPanel.SetActive(true);
        GameObject button = GameObject.FindGameObjectWithTag("shopButton");
        GameObject fbutton = GameObject.FindGameObjectWithTag("fbutton");
        GameObject sbutton = GameObject.FindGameObjectWithTag("sbutton");
        GameObject mbutton = GameObject.FindGameObjectWithTag("mbutton");
        button.GetComponent<Button>().onClick.RemoveAllListeners();
        button.GetComponent<Button>().onClick.AddListener(BuyWool);
        fbutton.GetComponent<Button>().onClick.RemoveAllListeners();
        fbutton.GetComponent<Button>().onClick.AddListener(FireWool);
        sbutton.GetComponent<Button>().onClick.RemoveAllListeners();
        sbutton.GetComponent<Button>().onClick.AddListener(StickyWool);
        mbutton.GetComponent<Button>().onClick.RemoveAllListeners();
        mbutton.GetComponent<Button>().onClick.AddListener(MagnetWool);
        ShopPanel.GetComponentInParent<Animator>().SetBool("IsOpen",true);;
        

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
        Debug.Log(transform.position);
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
