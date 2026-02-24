using UnityEngine;

public class thrownWool : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        Sprite woolSprite = GetComponent<SpriteRenderer>().sprite;
        Debug.Log(woolSprite.name);
        if(woolSprite.name == "stickyWool")
        {
            GetComponent<stickyWool>().Create();
            Destroy(gameObject);
        }
        if(woolSprite.name == "fireWool")
        {
            GetComponent<fireWool>().Create();
            Destroy(gameObject);
        }
        if(woolSprite.name == "basicWool")
        {
            GetComponent<basicWool>().Create();
            Destroy(gameObject);
        }
    }
}
