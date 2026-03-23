using UnityEngine;

public class stickObjects : MonoBehaviour
{
    public float radius = 0.6f;
    public LayerMask layerMask;

    [SerializeField] GameObject joinObject;

    public bool Check()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, radius, layerMask);
        Debug.Log(hits);
        if(hits.Length == 2)
        {
            // Create a FixedJoint2D at runtime
            if(hits[0].gameObject.GetComponent<FixedJoint2D>() == null)
            {
                

                GameObject join = Instantiate(joinObject);
                join.transform.position = transform.position;

                FixedJoint2D joint1 = join.AddComponent<FixedJoint2D>();
                joint1.connectedBody = hits[1].gameObject.GetComponent<Rigidbody2D>();
                joint1.connectedAnchor = transform.position; // Automatically set anchor points
                joint1.enableCollision = false; // Prevent them from colliding with each other
                joint1.frequency = 10f;
                FixedJoint2D joint2 = join.AddComponent<FixedJoint2D>();
                joint2.connectedBody = hits[0].gameObject.GetComponent<Rigidbody2D>();
                joint2.connectedAnchor = transform.position; // Automatically set anchor points
                joint2.enableCollision = false; // Prevent them from colliding with each other
                joint2.frequency = 10f;

                Destroy(gameObject);
                return true;
            }
        }
        return false;
    }

    // Optional: Draw the circle in Scene view
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
