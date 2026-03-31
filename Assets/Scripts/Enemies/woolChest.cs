using UnityEngine;

public class woolChest : MonoBehaviour, IInteractable
{
    [SerializeField] GameObject woolPrefab;
    [SerializeField] Sprite[] lootTable;
    int arrayLength;
    int index;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        index = 0;
        arrayLength = lootTable.Length;
    }
    public void Interact()
    {
        if(index <= arrayLength-1)
        {
            GameObject newObject = Instantiate(woolPrefab);
            newObject.transform.position = transform.position;
            newObject.GetComponent<SpriteRenderer>().sprite = lootTable[index];
        }
        index += 1;
        if(index > arrayLength-1)
        {
            GetComponent<SpriteRenderer>().color = Color.gray;GetComponent<Collider2D>().enabled = false;
        }
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
