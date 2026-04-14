using UnityEngine;

public class findBounds : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GameObject.FindGameObjectWithTag("CameraBounds") != null)
        {
            PolygonCollider2D bounds = GameObject.FindGameObjectWithTag("CameraBounds").GetComponent<PolygonCollider2D>();
            GetComponent<Unity.Cinemachine.CinemachineConfiner2D>().BoundingShape2D = bounds;
        }
    }
}
