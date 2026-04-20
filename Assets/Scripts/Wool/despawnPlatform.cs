using UnityEngine;

public class despawnPlatform : MonoBehaviour
{
    [SerializeField] float time;
    [SerializeField] GameObject basicWool;
    [SerializeField] Sprite droppedSprite;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GetComponent<SFXPlayer>().PlaySound(0,0.1f);
        Invoke(nameof(Despawn),time);
        
    }

    private void Despawn()
    {
        GameObject newObj = Instantiate(basicWool);
        newObj.GetComponent<SpriteRenderer>().sprite = droppedSprite;
        newObj.transform.position = transform.position;
        newObj.GetComponent<woolPickup>().scatterMin = 1f;
        newObj.GetComponent<woolPickup>().scatterMax = 2f;
        Destroy(gameObject);
    }
}
