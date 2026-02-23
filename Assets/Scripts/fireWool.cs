using UnityEngine;

public class fireWool : MonoBehaviour
{
    [SerializeField] GameObject firePrefab;
    
    public void Create()
    {
        GameObject newObj = Instantiate(firePrefab);
        newObj.transform.position = transform.position;
    }
}

