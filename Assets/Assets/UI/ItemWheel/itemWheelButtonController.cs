using UnityEngine;
using UnityEditor.UI;
using TMPro;
using Microsoft.Unity.VisualStudio.Editor;
using System.Data;
public class itemWheelButtonController : MonoBehaviour
{
    public int ID;
    private Animator anim;
    public string itemName;
    public TextMeshProUGUI itemText;
    public UnityEngine.UI.Image selectedItem;
    private bool selected = false;
    public Sprite icon;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (selected)
        {
            selectedItem.sprite = icon;
            itemText.text = itemName;
        }
    }

    public void Selected()
    {
        selected = true;
        itemWheelController.itemID = ID;
    }

    public void Deselected()
    {
        selected = false;
        itemWheelController.itemID = 0;
    }

    public void HoverEnter()
    {
        anim.SetBool("hover",true);
        itemText.text = itemName;
    }
    public void HoverExit()
    {
        anim.SetBool("hover",false);
        itemText.text = "";
    }
}
