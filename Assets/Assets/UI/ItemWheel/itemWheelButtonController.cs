using UnityEngine;
using UnityEditor.UI;
using TMPro;
using Microsoft.Unity.VisualStudio.Editor;
using System.Data;
using UnityEngine.UI;
public class itemWheelButtonController : MonoBehaviour
{
    [SerializeField] woolInventoryManager woolInventory;
    public int ID;
    private int amount;
    private Animator anim;
    public string itemName;
    public TextMeshProUGUI itemText;
    public GameObject heldWool;
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
        isOpen = GetComponentInParent<itemWheelController>().itemWheelSelected;
        if(isOpen)
        {
            amount = 0;
            for(int i = 0;i<woolInventory.woolHeld.Length;i++)
            {
                if(woolInventory.woolHeld[i].GetComponent<SpriteRenderer>().sprite.name == icon.name && woolInventory.woolHeld[i].GetComponent<SpriteRenderer>().enabled == true)
                {
                    amount += 1;
                }
            }
            if(amount <=0)
            {
                GetComponent<Button>().interactable = false;
                return;
            }
            else
            {
                GetComponent<Button>().interactable = true;
            }
        }

    }

    public void Selected()
    {
        if(!isOpen){return;}
        selected = true;
        itemWheelController.itemID = ID;
        Debug.Log("bing");
        GetComponentInParent<itemWheelController>().AddWool(icon);
        /*if(GetComponentInParent<itemWheelController>().woolFull() == false)
        {
            GetComponentInParent<itemWheelController>().AddWool();
        }*/
        heldWool.GetComponent<SpriteRenderer>().sprite = icon;
    }

    public void Deselected()
    {
        //if(!isOpen){return;}
        selected = false;
        itemWheelController.itemID = 0;
    }

    public void HoverEnter()
    {
        if(!isOpen){return;}
        anim.SetBool("hover",true);
        itemText.text = $"{itemName} --- {amount}";
    }
    public void HoverExit()
    {
        if(!isOpen){return;}
        anim.SetBool("hover",false);
        itemText.text = "";
    }
}
