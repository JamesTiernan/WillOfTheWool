using UnityEngine;

public class itemPickup : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponentInChildren<heldItem>().heldObject = GetComponent<SpriteRenderer>().sprite;
        Destroy(gameObject);
    }

    public bool IsInteractable()
    {
        return true;
    }
}
