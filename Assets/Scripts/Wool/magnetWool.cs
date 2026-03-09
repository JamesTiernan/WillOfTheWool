using UnityEngine;

public class magnetWool : MonoBehaviour
{
    [SerializeField] LayerMask layer;
    [SerializeField] float timer;
    [SerializeField] GameObject woolDrop;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(GetComponent<SpriteRenderer>().sprite.name == "magnetWool")
        {
            Invoke(nameof(Despawn),timer);
        }
    }

    void Despawn()
    {
        GameObject newObj = Instantiate(woolDrop);
        newObj.GetComponent<SpriteRenderer>().sprite = GetComponent<SpriteRenderer>().sprite;
        newObj.transform.position = transform.position;
        Destroy(gameObject);
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
