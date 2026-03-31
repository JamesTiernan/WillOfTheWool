using UnityEngine;

public class trajectoryDisplay : MonoBehaviour
{
    [SerializeField] LineRenderer line;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Plot()
    {
        line.positionCount += 1;
        line.SetPosition(line.positionCount, transform.position); 
    }
}
