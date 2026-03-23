using UnityEngine;

public class doorSpawn : MonoBehaviour, IInteractable
{
    [SerializeField] GameObject objectSpawn;
    [SerializeField] bool requireObject;
    [SerializeField] Sprite required;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        objectSpawn.GetComponent<BoxCollider2D>().enabled = false;
    }
    public void Interact()
    {
        objectSpawn.GetComponent<BoxCollider2D>().enabled = true;
        GameObject newObject = Instantiate(objectSpawn);
        newObject.transform.position = transform.position;
    }

    public bool IsInteractable()
    {
        if(requireObject)
        {
            if(GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<heldItem>().heldObject == required)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return true;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
