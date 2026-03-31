using UnityEngine;

public class entityHealth : MonoBehaviour
{
    [SerializeField] int maxHealth;
    int health;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       health = maxHealth; 
    }

    public void Damage(int amount)
    {
        health -= amount;
        Debug.Log($"{gameObject.name}: Health:{health}");
        if(health < 1)
        {
            Destroy(gameObject);
        }
    }
}
