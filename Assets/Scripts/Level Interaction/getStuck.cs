using UnityEngine;

public class getStuck : MonoBehaviour
{
    [Header("Sticky")]
    [SerializeField] LayerMask stickyLayer;
    [SerializeField] Vector2 stickyMultiplier = new Vector2(0.4f,0.8f);
    Rigidbody2D rb;
    public bool isStuck;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if(isStuck){rb.linearVelocityX *= stickyMultiplier.x;rb.linearVelocityY *= stickyMultiplier.y;}
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Sticky")){isStuck = true;}
        
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Sticky")){isStuck = false;}
    }

}
