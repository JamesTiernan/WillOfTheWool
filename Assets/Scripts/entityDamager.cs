using UnityEngine;

public class entityDamager : MonoBehaviour
{
    [SerializeField] int radius;
    [SerializeField] int amount;
    [SerializeField] LayerMask entityDamageLayer;

    // Update is called once per frame
    void Update()
    {
        Collider2D coll = Physics2D.OverlapCircle(transform.position,radius,entityDamageLayer);
        if(coll != null)
        {
            coll.gameObject.GetComponent<entityHealth>().Damage(amount);
            Destroy(gameObject);
        }
    }

}
