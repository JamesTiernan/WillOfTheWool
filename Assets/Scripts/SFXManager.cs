using UnityEngine;
using UnityEngine.UI;

public class SFXManager : MonoBehaviour
{

    [SerializeField] private Slider slider;
    float volume;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }


    public float SFXValue()

    {
        volume = slider.value;
        return volume;

    }
    


}
