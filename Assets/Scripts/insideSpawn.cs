using UnityEngine;
using System.Collections;

public class insideSpawn : MonoBehaviour
{

    [SerializeField] Transform Spawnpoint;

    private GameObject player;
    [SerializeField] private bool inBounds;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(inBounds == true)
        {Spawnpoint.position = player.transform.position;}
        else{return;}
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            inBounds = true;
            
         }
    }
    
    void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            inBounds = false;
            
         }

    }
    
    


}