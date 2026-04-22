using UnityEngine;

public class woolSFX : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GetComponent<SFXPlayer>().PlaySound(0,0.1f);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
