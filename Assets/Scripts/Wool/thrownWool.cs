using UnityEngine;

public class thrownWool : MonoBehaviour
{
    public Sprite woolSprite;
    int check;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        woolSprite = GetComponent<SpriteRenderer>().sprite;
        Debug.Log(woolSprite.name);
        
    }

    // Update is called once per frame
    void Update()
    {
        if(woolSprite.name == "magnetWool")
        {
            GetComponent<magnetWool>().Check();
        }
    }
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        check += 1;
        CheckMyWool();
    }

    void CheckMyWool()
    {
        if(check == 1)
        {
            woolSprite = GetComponent<SpriteRenderer>().sprite;
            Debug.Log(woolSprite.name);
            if(woolSprite.name == "stickyWool")
            {
                if(!GetComponent<stickObjects>().Check())
                {
                    GetComponent<stickyWool>().Create();
                    Destroy(gameObject);
                }
            
                
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
}

