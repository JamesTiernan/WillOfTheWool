using UnityEngine;

public class magnetWool : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CheckMagnetic()
    {
        Debug.Log(Physics2D.OverlapCircle(new Vector2(transform.position.x, transform.position.y), 1f));
    }
}
