using UnityEngine;

public class visualWoolManager : MonoBehaviour
{
    [SerializeField] healthManager health;
    [SerializeField] Sprite emptySprite;
    [SerializeField] Sprite woolSprite;
    [SerializeField] GameObject[] woolVisuals;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(health.health < 0)
        {
            Debug.Log("GAME OVER");
        }
        for(int i =13;i >= 0; i--)
        {
            if(health.health < 1){woolVisuals[i].GetComponent<SpriteRenderer>().sprite = emptySprite;}
            else if(i < health.health)
            {
                woolVisuals[i].GetComponent<SpriteRenderer>().sprite = woolSprite;
            }
            else
            {
                woolVisuals[i].GetComponent<SpriteRenderer>().sprite = emptySprite;
            }
        }
    }
}
