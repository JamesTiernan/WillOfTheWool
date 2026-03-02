using UnityEngine;
using System.Collections;
using UnityEngine.InputSystem;

public class InteractionDetect : MonoBehaviour
{
    private IInteractable InteractableInRange = null;
    public GameObject InteractIcon;


    void Start()
    {
        InteractIcon.SetActive(false);
    }

    void Update()
    {
        if(GetComponentInParent<playerController>().flipped)
        {
            InteractIcon.transform.localScale = new Vector2(-1.4f,1.4f);
        }else{InteractIcon.transform.localScale = new Vector2(1.4f,1.4f);}
    }

    public void OnInteract(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            InteractableInRange?.Interact();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Trigger hit: " + collision.gameObject.name);
        if (collision.TryGetComponent(out IInteractable interactable) && interactable.IsInteractable())
        {
            InteractableInRange = interactable;
            InteractIcon.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out IInteractable interactable) && interactable == InteractableInRange)
        {
            NPC npc = collision.GetComponent<NPC>();
            if(npc != null)
            {
                npc.EndDialogue();
            }
            InteractableInRange = null;
            InteractIcon.SetActive(false);
        }
    }
}
