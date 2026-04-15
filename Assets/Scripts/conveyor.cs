using UnityEngine;

public class conveyor : MonoBehaviour
{
    Collider2D collCheck;
    [SerializeField] float conveyorSpeed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        collCheck = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<conveyorEffect>() != null)
        {
            collision.gameObject.GetComponent<conveyorEffect>().origin = true;
            collision.gameObject.GetComponent<conveyorEffect>().speed = conveyorSpeed;
            collision.gameObject.GetComponent<conveyorEffect>().onConveyor = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<conveyorEffect>() != null)
        {
            collision.gameObject.GetComponent<conveyorEffect>().speed = 0;
            collision.gameObject.GetComponent<conveyorEffect>().onConveyor = false;
        }
    }
}
