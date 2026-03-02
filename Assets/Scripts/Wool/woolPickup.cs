using UnityEngine;

public class woolPickup : MonoBehaviour
{
    [SerializeField] int value;
    private bool canPickup;
    private Rigidbody2D rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        canPickup = false;
        rb = GetComponent<Rigidbody2D>();
        rb.linearVelocity = new Vector2(Random.Range(-4f,4f),Random.Range(1.3f,5f));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(!canPickup){return;}
        Debug.Log(other);
        if(other.CompareTag("Player"))
        {
            other.GetComponent<healthManager>().Heal(value);
            //other.GetComponent<visualWoolManager>();
            Destroy(gameObject);
        }
        else{return;}
    }
}
