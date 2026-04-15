using UnityEngine;

public class conveyorEffect : MonoBehaviour
{
    public bool origin;
    public bool onConveyor = false;
    public float speed;

    Rigidbody2D rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(onConveyor)
        {
            rb.linearVelocityX = speed;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(onConveyor)
        {
            if (collision.gameObject.GetComponent<conveyorEffect>() != null)
            {
                collision.gameObject.GetComponent<conveyorEffect>().origin = false;
                collision.gameObject.GetComponent<conveyorEffect>().speed = speed;
                collision.gameObject.GetComponent<conveyorEffect>().onConveyor = true;
            }
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if(onConveyor)
        {
            if (collision.gameObject.GetComponent<conveyorEffect>() != null)
            {
                collision.gameObject.GetComponent<conveyorEffect>().speed = 0;
                collision.gameObject.GetComponent<conveyorEffect>().onConveyor = false;
            }
        }
    }
}
