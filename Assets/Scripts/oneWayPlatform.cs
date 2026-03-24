using UnityEngine;

public class oneWayPlatform : MonoBehaviour
{
    GameObject player;
    Collider2D coll;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        coll = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(player.GetComponent<Rigidbody2D>().linearVelocityY >= 0)
        {
            coll.enabled = false;
        }
        else
        {
            coll.enabled = true;
        }
    }
}
