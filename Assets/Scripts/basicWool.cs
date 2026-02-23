using UnityEngine;

public class basicWool : MonoBehaviour
{
    [SerializeField] int gridSize;
    [SerializeField] GameObject woolPrefab;
    
    public void Create()
    {
        GameObject newObj = Instantiate(woolPrefab);
        newObj.transform.position = new Vector2(Mathf.Round(transform.position.x / gridSize) * gridSize,Mathf.Round(transform.position.y / gridSize) * gridSize);
    }
}
