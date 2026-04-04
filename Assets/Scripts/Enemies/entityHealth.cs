using UnityEngine;
using System.Collections;
public class entityHealth : MonoBehaviour
{

    private SpriteRenderer spriteRenderer;
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
        StartCoroutine(DamageFlash());
        if(health < 1)
        {
            Destroy(gameObject);
        }
    }

        IEnumerator DamageFlash()
    {
    spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    spriteRenderer.color = new Color(1, 0, 0, .75f);
    yield return new WaitForSeconds(.2f);
    spriteRenderer.color = new Color(1, 1, 1, 1); 
    }
}
