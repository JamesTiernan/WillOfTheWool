using UnityEngine;

public class healthManager : MonoBehaviour
{
    [SerializeField] public int maxHealth;
    [SerializeField] GameObject damageEffect;
    [SerializeField] public int health;

    public bool isDead = false;

    [SerializeField] public GameObject gameoverScreen;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameoverScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(!isDead)
        {
            if(health < 0)
            {
                isDead = true;
                Debug.Log("GAME VOER SCREENEENR");
                health = 0;
                gameoverScreen.SetActive(true);
            }
        }
    }

    public void Damage(int amount ,bool drop)
    {
        if(GetComponent<playerController>().invincible){return;}
        if(health == 0)
        {
            isDead = true;
            Debug.Log("GAME VOER SCREENEENR");
            health = 0;
            gameoverScreen.SetActive(true);
            return; 
        }
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
                newObj.GetComponent<woolPickup>().scatterMin = 6f;
                newObj.GetComponent<woolPickup>().scatterMax = 8f;
            }
        }

    }

    public void Heal(int amount,Sprite woolType)
    {
        if(GetComponent<woolInventoryManager>().GainWool(woolType) == false){return;}
        if(health > maxHealth)
        {
            health = maxHealth;
        }
    }
}
