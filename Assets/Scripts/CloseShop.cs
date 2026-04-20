using UnityEngine;



public class CloseShop : MonoBehaviour
{

    [SerializeField] GameObject ShopPanel;

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Exited");
            ShopPanel.SetActive(false);
        }
    }
}


