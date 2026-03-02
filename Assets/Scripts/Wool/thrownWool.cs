using UnityEngine;

public class thrownWool : MonoBehaviour
{
    Sprite woolSprite;
    magnetWool updateScript;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        woolSprite = GetComponent<SpriteRenderer>().sprite;
        Debug.Log(woolSprite.name);
        if(woolSprite.name == "magnetWool")
        {
            updateScript = GetComponent<magnetWool>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(updateScript != null)
        {
            updateScript.CheckMagnetic();
        }
    }
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        woolSprite = GetComponent<SpriteRenderer>().sprite;
        Debug.Log(woolSprite.name);
        if(woolSprite.name == "stickyWool")
        {
            GetComponent<stickyWool>().Create();
            Destroy(gameObject);
        }
        if(woolSprite.name == "fireWool")
        {
            GetComponent<fireWool>().Create();
            Destroy(gameObject);
        }
        if(woolSprite.name == "basicWool")
        {
            GetComponent<basicWool>().Create();
            Destroy(gameObject);
        }
    }
}
