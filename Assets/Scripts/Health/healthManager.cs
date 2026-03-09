using UnityEngine;

public class healthManager : MonoBehaviour
{
    [SerializeField] public int maxHealth;
    [SerializeField] GameObject damageEffect;
    [SerializeField] public int health;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Damage(int amount ,bool drop)
    {
        if(GetComponent<playerController>().stunned){return;}
        Sprite newSprite = null;
        for(int i = 0; i<amount; i++)
        {
            for(int j =13;j>=0;j--)
            {
                if(GetComponent<woolInventoryManager>().woolHeld[j].GetComponent<SpriteRenderer>().enabled == true)
                {
                    GetComponent<woolInventoryManager>().woolHeld[j].GetComponent<SpriteRenderer>().enabled = false;
                    newSprite = GetComponent<woolInventoryManager>().woolHeld[j].GetComponent<SpriteRenderer>().sprite;
                    health -= 1;
                    j = -1;
                }
            }
            if(drop && health >=1)
            {
                GameObject newObj = Instantiate(damageEffect);
                newObj.transform.position = transform.position;
                newObj.GetComponent<SpriteRenderer>().sprite = newSprite;
            }
            
            
            if(health < 0){health =0; Debug.Log("u dead");}
        }
            /*
            newObj.GetComponent<SpriteRenderer>().sprite = heldWool.GetComponent<SpriteRenderer>().sprite;
            visual wool must match wool and also update this too :)
            */
        
    }

    public void Heal(int amount,Sprite woolType)
    {
        if(GetComponent<woolInventoryManager>().GainWool(woolType) == false){return;}
        health += amount;
        if(health > maxHealth)
        {
            health = maxHealth;
        }
    }
}
