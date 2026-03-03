using UnityEngine;

public class woolHoover : MonoBehaviour
{
    [SerializeField] LayerMask playerLayer;
    GameObject other;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    void FixedUpdate()
    {
        Collider2D otherCollider = Physics2D.OverlapCircle(gameObject.transform.position,2,playerLayer);
        if(otherCollider != null)
        {
            other = otherCollider.gameObject;
            if(other != null)
            {
                if(!GetComponentInParent<woolPickup>().canPickup){return;}
                Debug.Log(other);
                if(other.gameObject.CompareTag("Player"))
                {
                    Rigidbody2D rb = GetComponentInParent<Rigidbody2D>();
                    Vector2 force = (Vector2)other.gameObject.transform.position - (Vector2)gameObject.transform.position;
                    Vector2 totalForce = force.normalized * 2;
                    rb.linearVelocity = totalForce;
                }
                else{return;}
            }
        }
        
        
        
    }
}
