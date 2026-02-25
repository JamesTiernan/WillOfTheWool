using UnityEngine;

public class magnetWool : MonoBehaviour
{
    [SerializeField] LayerMask layer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(new Vector2(transform.position.x, transform.position.y),2f);
    }

    public void CheckMagnetic()
    {
        
        Collider2D other = Physics2D.OverlapCircle(new Vector2(transform.position.x, transform.position.y), 2f,layer);
        if(other != null)
        {
            GameObject otherObject = other.gameObject;
            if(otherObject.CompareTag("Magnetic"))
            {
                Debug.Log("im working");
                Rigidbody2D rb = otherObject.GetComponent<Rigidbody2D>();
                Vector2 force = (Vector2)otherObject.transform.position - (Vector2)gameObject.transform.position;
                Vector2 totalForce = force.normalized * -5;
                otherObject.GetComponent<Rigidbody2D>().linearVelocity = totalForce;
                Debug.Log($"YOU: {totalForce}");
            }
        }

    }
}
