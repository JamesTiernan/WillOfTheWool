using UnityEngine;

public class doorSpawn : MonoBehaviour, IInteractable
{
    [SerializeField] GameObject objectSpawn;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        objectSpawn.SetActive(false);
    }
    public void Interact()
    {
        objectSpawn.SetActive(true);
        GameObject newObject = Instantiate(objectSpawn);
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
