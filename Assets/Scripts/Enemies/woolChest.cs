using UnityEngine;

public class woolChest : MonoBehaviour, IInteractable
{
    [SerializeField] GameObject[] lootTable;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    public void Interact()
    {
        GameObject newObject = Instantiate(lootTable[0]);
        newObject.transform.position = transform.position;
    }

    public bool IsInteractable()
    {
        return true;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
