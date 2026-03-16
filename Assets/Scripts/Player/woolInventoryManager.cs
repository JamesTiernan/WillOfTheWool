using UnityEngine;

public class woolInventoryManager : MonoBehaviour
{
    [SerializeField] healthManager health;
    [SerializeField] Sprite emptySprite;
    [SerializeField] Sprite woolSprite;
    [SerializeField] public GameObject[] woolHeld;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*
        for(int i =13;i >= 0; i--)
        {
            if(health.health < 1){woolHeld[i].GetComponent<SpriteRenderer>().sprite = emptySprite;}
            else if(i < health.health)
            {
                woolHeld[i].GetComponent<SpriteRenderer>().enabled = true;
            }
            else
            {
                woolHeld[i].GetComponent<SpriteRenderer>().enabled = false;
            }
        }*/
    }

    public bool LoseWool(Sprite woolType)
    {
        // Check for wool in inventory, set as disabled and return once found.
        for(int i =13;i>=0;i--)
        {
            if(woolHeld[i].GetComponent<SpriteRenderer>().sprite.name == woolType.name && woolHeld[i].GetComponent<SpriteRenderer>().enabled == true)
            {
                woolHeld[i].GetComponent<SpriteRenderer>().enabled = false;
                GetComponent<healthManager>().health -= 1;
                return true;
            }
        }
        return false;
    }

    public void RespawnWool()
    {
        // Check for wool in inventory, set as disabled and return once found.
        for(int i =13;i>=0;i--)
        {
            woolHeld[i].GetComponent<SpriteRenderer>().enabled = true;
        }
    }

    public bool GainWool(Sprite woolType)
    {
        // Check if wool already in inventory and disabled, enable it if so. Otherwise replace disabled wool with new.
        for(int i =13;i>=0;i--)
        {
            if(woolHeld[i].GetComponent<SpriteRenderer>().sprite.name == woolType.name && woolHeld[i].GetComponent<SpriteRenderer>().enabled == false)
            {
                woolHeld[i].GetComponent<SpriteRenderer>().enabled = true;
                GetComponent<healthManager>().health += 1;
                return true;
            }
            
        }
        // Attempt to replace a disabled wool with the new.
        for(int i =13;i>=0;i--)
        {
            if(woolHeld[i].GetComponent<SpriteRenderer>().enabled == false)
            {
                woolHeld[i].GetComponent<SpriteRenderer>().sprite = woolType; 
                woolHeld[i].GetComponent<SpriteRenderer>().enabled = true;
                GetComponent<healthManager>().health += 1;
                return true;
            }
            
        }

        // Return false if neither are valid options.
        return false;
    }

}
