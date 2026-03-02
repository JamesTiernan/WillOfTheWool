using UnityEngine;
using UnityEditor.UI;
using TMPro;
using Microsoft.Unity.VisualStudio.Editor;
using System.Data;
public class itemWheelButtonController : MonoBehaviour
{
    [SerializeField] woolInventoryManager woolInventory;
    public int ID;
    private int amount;
    private Animator anim;
    public string itemName;
    public TextMeshProUGUI itemText;
    public GameObject selectedItem;
    private bool selected = false;
    public Sprite icon;

    bool isOpen = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        amount = 0;
        for(int i = 0;i<woolInventory.woolHeld.Length;i++)
        {
            if(woolInventory.woolHeld[i].name == itemName)
            {
                amount += 1;
            }
        }
        
        isOpen = GetComponentInParent<itemWheelController>();
        if (selected)
        {
            selectedItem.GetComponent<SpriteRenderer>().sprite = icon;
            itemText.text = $"{itemName} --- {amount}";
        }
    }

    public void Selected()
    {
        if(!isOpen){return;}
        selected = true;
        itemWheelController.itemID = ID;
    }

    public void Deselected()
    {
        if(!isOpen){return;}
        selected = false;
        itemWheelController.itemID = 0;
    }

    public void HoverEnter()
    {
        if(!isOpen){return;}
        anim.SetBool("hover",true);
        itemText.text = itemName;
    }
    public void HoverExit()
    {
        if(!isOpen){return;}
        anim.SetBool("hover",false);
        itemText.text = "";
    }
}
