using UnityEngine;

public class woolPickup : MonoBehaviour
{
    [SerializeField] int value;
    [Header("Lights")]
    [SerializeField] GameObject fireLight;
    [SerializeField] GameObject basicLight;
    [SerializeField] GameObject stickyLight;
    [SerializeField] GameObject magnetLight;
    public bool canPickup;
    public float scatterMin;
    public float scatterMax;
    private Rigidbody2D rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        canPickup = false;
        rb = GetComponent<Rigidbody2D>();
        if(Random.Range(0,6) > 3)
        {
            rb.linearVelocityX = Random.Range(scatterMin,scatterMax) * -1;
        }
        else{rb.linearVelocityX = Random.Range(scatterMin,scatterMax);}
        
        rb.linearVelocityY = Random.Range(3f,5.4f);
        Invoke(nameof(PickupCooldown),1f);

        Sprite woolSprite = GetComponent<SpriteRenderer>().sprite;

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
    
    void PickupCooldown()
    {
        canPickup = true;
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(!canPickup){return;}
        //Debug.Log(other);
        if(other.gameObject.CompareTag("Player"))
        {
            if(other.gameObject.GetComponent<healthManager>().health < other.gameObject.GetComponent<healthManager>().maxHealth)
            {
                Sprite mySprite = GetComponent<SpriteRenderer>().sprite;
                
                other.gameObject.GetComponent<healthManager>().Heal(value, mySprite);
                //other.GetComponent<visualWoolManager>();
                Destroy(gameObject);
            }
        }
        else{return;}
    }
}
