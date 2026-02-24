using UnityEngine;

public class bounceShroom : MonoBehaviour
{
    [SerializeField] float bounceForce;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.GetComponent<canBounce>() !=null)
        {
            Debug.Log(other);
            Vector2 force = (Vector2)other.transform.position - (Vector2)gameObject.transform.position;
            Debug.Log(force);
            Vector2 totalForce = force.normalized * bounceForce;
            Debug.Log($"Force: {totalForce}");
            other.GetComponent<Rigidbody2D>().linearVelocity = totalForce;
        }
    }
}
