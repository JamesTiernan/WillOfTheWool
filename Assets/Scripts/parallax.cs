using UnityEngine;
using UnityEngine.SceneManagement;

public class parallax : MonoBehaviour
{
    GameObject cam;
    Vector3 lastCamPos;
    [SerializeField] Vector3 parallaxMultiplier;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cam = GameObject.FindGameObjectWithTag("MainCamera");
        lastCamPos = cam.transform.position;
    }

    void Update()
    {
        if(cam != null)
        {
            Vector3 deltaMovement = cam.transform.position - lastCamPos;
            transform.position += new Vector3(deltaMovement.x * parallaxMultiplier.x,deltaMovement.y * parallaxMultiplier.y);
            lastCamPos = cam.transform.position;
        }
    }
}
