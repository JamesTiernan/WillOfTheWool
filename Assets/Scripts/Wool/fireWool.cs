using UnityEngine;

public class fireWool : MonoBehaviour
{
    [SerializeField] GameObject firePrefab;
    [SerializeField] GameObject fireLight;

    void Start()
    {
        if(GetComponent<thrownWool>().woolSprite.name == "fireWool")
        {
            GameObject light = Instantiate(fireLight);
            light.transform.parent = transform;
            light.transform.position = transform.position;
        }
    }
    public void Create()
    {
        GameObject newObj = Instantiate(firePrefab);
        newObj.transform.position = transform.position;
    }
}

