using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;



public class CloseShop : MonoBehaviour
{

    [SerializeField] GameObject ShopPanel;

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if(ShopPanel != null)
            {
                ShopPanel.GetComponentInParent<Animator>().SetBool("IsOpen",false);
            Debug.Log("Exited");
            }
        }
    }
}


