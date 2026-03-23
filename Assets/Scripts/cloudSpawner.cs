using UnityEngine;

public class cloudSpawner : MonoBehaviour
{
    [SerializeField] Sprite[] cloudSprites;
    [SerializeField] GameObject baseObject;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Invoke(nameof(makeCloud),Random.Range(1,2));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void makeCloud()
    {
        GameObject newObject = Instantiate(baseObject,transform);
        newObject.transform.position = transform.position;
        newObject.transform.position += new Vector3(0,Random.Range(-6,6),0);
        newObject.GetComponent<SpriteRenderer>().sprite = cloudSprites[Random.Range(0,cloudSprites.Length)];
        Invoke(nameof(makeCloud),Random.Range(1f,2.5f));
    }
}
