using UnityEngine;

public class woolHoover : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void OnTriggerEnter2D(Collider2D other)
    {
        if(!GetComponentInParent<woolPickup>().canPickup){return;}
        Debug.Log(other);
        if(other.gameObject.CompareTag("Player"))
        {
            Rigidbody2D rb = GetComponentInParent<Rigidbody2D>();
            Vector2 force = (Vector2)other.gameObject.transform.position - (Vector2)gameObject.transform.position;
            Vector2 totalForce = force.normalized * -5;
            rb.linearVelocity = totalForce;
        }
        else{return;}
    }

}
