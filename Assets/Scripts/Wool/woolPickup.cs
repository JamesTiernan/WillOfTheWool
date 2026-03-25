using UnityEngine;

public class woolPickup : MonoBehaviour
{
    [SerializeField] int value;
    [SerializeField] GameObject fireLight;
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
        if(GetComponent<SpriteRenderer>().sprite.name == "fireWool")
        {
            GameObject light = Instantiate(fireLight);
            light.transform.parent = transform;
            light.transform.position = transform.position;
        }
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
