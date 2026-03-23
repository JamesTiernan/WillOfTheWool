using UnityEngine;

public class checkpoint : MonoBehaviour
{
    [SerializeField] Sprite active;
    [SerializeField] Sprite inactive;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
           lastCheckpoint checkpointSet = other.GetComponent<playerController>().checkpointManager;
           checkpointSet.checkpointPosition = transform;
           GetComponent<SpriteRenderer>().sprite = active;
        }
    }
}
