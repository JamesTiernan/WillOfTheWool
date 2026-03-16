using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.InputSystem;

public class itemWheelController : MonoBehaviour
{
    [SerializeField] GameObject selectedWool;
    public Animator anim;
    public bool itemWheelSelected = false;
    public GameObject selectedItem;
    public Sprite noImage;
    public static int itemID;

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

        
        selectedWool.GetComponent<UnityEngine.UI.Image>().sprite = selectedItem.GetComponent<SpriteRenderer>().sprite;
    }
}
