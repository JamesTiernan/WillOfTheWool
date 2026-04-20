using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections;

public class OpenShop : MonoBehaviour, IInteractable
{

    [SerializeField] GameObject woolPrefab;
    [SerializeField] private GameObject ShopPanel;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
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
        GameObject newObject = Instantiate(woolPrefab);
        newObject.transform.position = transform.position;
        
    }
}
