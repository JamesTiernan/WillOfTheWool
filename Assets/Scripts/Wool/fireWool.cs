using UnityEngine;

public class fireWool : MonoBehaviour
{
    [SerializeField] GameObject firePrefab;

    void Start()
    {
        
    }
    public void Create()
    {
        GameObject newObj = Instantiate(firePrefab);
        newObj.transform.position = transform.position;
        newObj.transform.position = new Vector3(newObj.transform.position.x,newObj.transform.position.y,0);
    }
}

