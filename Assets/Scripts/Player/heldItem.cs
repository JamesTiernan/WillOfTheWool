using UnityEngine;

public class heldItem : MonoBehaviour
{
    public Sprite heldObject;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<SpriteRenderer>().sprite = heldObject;
    }
}
