using UnityEngine;

[ExecuteInEditMode]
public class backgroundFade : MonoBehaviour
{
    [SerializeField] Color colour;
    
    // Update is called once per frame
    void Update()
    {
        SpriteRenderer[] sprites = GetComponentsInChildren<SpriteRenderer>();

        foreach(SpriteRenderer sprite in sprites)
        {
            sprite.color = colour;
        }
        
    }
}
