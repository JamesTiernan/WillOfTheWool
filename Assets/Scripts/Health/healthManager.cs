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
        for(int i = 0; i<amount; i++)
        {
            if(drop)
            {
                GameObject newObj = Instantiate(damageEffect);
                newObj.transform.position = transform.position;
            }
            /*
            newObj.GetComponent<SpriteRenderer>().sprite = heldWool.GetComponent<SpriteRenderer>().sprite;
            visual wool must match wool and also update this too :)
            */
        }
        health -= amount;
        if(health < 0){health =0; Debug.Log("u dead");}
    }

    public void Heal(int amount)
    {
        health += amount;
        if(health > maxHealth)
        {
            health = maxHealth;
        }
    }
}
