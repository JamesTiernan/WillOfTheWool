using UnityEngine;
using System.Collections;

public class boundsDetect : MonoBehaviour
{

    [SerializeField] Transform Spawnpoint;

    private GameObject player;
    private bool inBounds = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }
    }


    void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            inBounds = false;
            player.transform.position = Spawnpoint.position;
            Debug.Log("Working");
            
         }

    }

     void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            inBounds = true;
            
         }

    }
}
