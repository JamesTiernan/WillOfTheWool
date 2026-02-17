using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.InputSystem;

public class itemWheelController : MonoBehaviour
{
    public Animator anim;
    public bool itemWheelSelected = false;
    public GameObject selectedItem;
    public Sprite noImage;
    public static int itemID;

    public void Open(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            itemWheelSelected = !itemWheelSelected;
        }

    }
    
    // Update is called once per frame
    void Update()
    {

        if(itemWheelSelected)
        {
            anim.SetBool("OpenItemWheel",true);
        }
        else
        {
            anim.SetBool("OpenItemWheel",false);
        }

        if(itemWheelSelected)
        {
            switch (itemID)
            {
                case 0: // No Item
                    selectedItem.GetComponent<SpriteRenderer>().sprite = noImage;
                    break;
                case 1: // Basic Wool
                    Debug.Log("Basic");
                    break;
                case 2: // Fire Wool
                    Debug.Log("Fire");
                    break;
                case 3: // Sticky Wool
                    Debug.Log("Sticky");
                    break;
                case 4: // Magnet Wool
                    Debug.Log("Magnet");
                    break;
            }
        }
    }
}
