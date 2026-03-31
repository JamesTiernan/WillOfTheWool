using UnityEngine;

public class thrownWool : MonoBehaviour
{
    [Header("Lights")]
    [SerializeField] GameObject fireLight;
    [SerializeField] GameObject basicLight;
    [SerializeField] GameObject stickyLight;
    [SerializeField] GameObject magnetLight;
    public Sprite woolSprite;
    int check;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        woolSprite = GetComponent<SpriteRenderer>().sprite;
        Debug.Log(woolSprite.name);

        GameObject lightSpawn = null;
        if(woolSprite.name == "fireWool")
        {
            lightSpawn = fireLight;
        }
        else if(woolSprite.name == "basicWool")
        {
            lightSpawn = basicLight;
        }
        else if(woolSprite.name == "magnetWool")
        {
            lightSpawn = magnetLight;
        }
        else if(woolSprite.name == "stickyWool")
        {
            lightSpawn = stickyLight;
        }

        if(lightSpawn == null)
        {
            lightSpawn = basicLight;
        }
        GameObject light = Instantiate(lightSpawn);
        light.transform.parent = transform;
        light.transform.position = transform.position;
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

