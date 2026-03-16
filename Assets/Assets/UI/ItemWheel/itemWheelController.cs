using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.InputSystem;

public class itemWheelController : MonoBehaviour
{
    [SerializeField] GameObject selectedWool;
    public Animator anim;
    public bool itemWheelSelected = false;
    public GameObject selectedItem;
    public GameObject heldWool;
    public Sprite noImage;
    public static int itemID;

    [SerializeField] GameObject[] woolSlots;
    [SerializeField] Sprite emptySprite;

    public void Open(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            itemWheelSelected = !itemWheelSelected;
        }

    }

    // Update is called once per frame
    void Update()
    {

        if (itemWheelSelected)
        {
            anim.SetBool("OpenItemWheel", true);
        }
        else
        {
            anim.SetBool("OpenItemWheel", false);
        }

        heldWool.GetComponent<SpriteRenderer>().sprite = woolSlots[0].GetComponent<UnityEngine.UI.Image>().sprite;
        //selectedWool.GetComponent<UnityEngine.UI.Image>().sprite = selectedItem.GetComponent<SpriteRenderer>().sprite;
    }

    public bool woolFull()
    {
        for(int i = 0;i==3;i++)
        {
            if(woolSlots[i].GetComponent<UnityEngine.UI.Image>().sprite == emptySprite)
            {
                return false;
            }
            
        }
        return true;
    }

    public void AddWool(Sprite woolType)
    {
        for(int i = 0;i == 3;i++)
        {
            if(woolSlots[i].GetComponent<UnityEngine.UI.Image>().sprite == noImage)
            {
                woolSlots[i].GetComponent<UnityEngine.UI.Image>().sprite = woolType;
                return;
            }
            
        }
    }
}
