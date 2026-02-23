using UnityEngine;

public class stickyWool : MonoBehaviour
{
    [SerializeField] GameObject stickyPrefab;
    
    public void Create()
    {
        GameObject newObj = Instantiate(stickyPrefab);
        newObj.transform.position = transform.position;

        Destroy(gameObject);
    }
}
