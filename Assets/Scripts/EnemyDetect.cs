using UnityEngine;

public class EnemyDetect : MonoBehaviour
{
    void Start()
    {
        

    }

   private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GetComponentInChildren<EnemySideways>().StartSwoop(other.gameObject.transform);

        }
       
       
        
    }
}
