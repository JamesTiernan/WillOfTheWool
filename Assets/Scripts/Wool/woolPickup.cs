using UnityEngine;

public class woolPickup : MonoBehaviour
{
    [SerializeField] int value;
    public bool canPickup;
    private Rigidbody2D rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        canPickup = false;
        rb = GetComponent<Rigidbody2D>();
        if(Random.Range(0,6) > 3)
        {
            rb.linearVelocityX = Random.Range(-3f,-5f);
        }
        else{rb.linearVelocityX = Random.Range(3f,5f);}
        
        rb.linearVelocityY = Random.Range(1.3f,5f);
        Invoke(nameof(PickupCooldown),0.5f);
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
            Sprite mySprite = GetComponent<SpriteRenderer>().sprite;
            other.gameObject.GetComponent<healthManager>().Heal(value, mySprite);
            //other.GetComponent<visualWoolManager>();
            Destroy(gameObject);
        }
        else{return;}
    }
}
