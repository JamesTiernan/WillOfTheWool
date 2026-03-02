using UnityEngine;

public class despawnPlatform : MonoBehaviour
{
    [SerializeField] GameObject basicWool;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Invoke(nameof(Despawn),5f);
    }

    private void Despawn()
    {
        GameObject newObj = Instantiate(basicWool);
        newObj.transform.position = transform.position;
        Destroy(gameObject);
    }
}
