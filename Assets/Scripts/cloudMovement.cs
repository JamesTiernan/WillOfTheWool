using UnityEngine;

public class cloudMovement : MonoBehaviour
{
    float movement;
    float speed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        speed = Random.Range(1f,3f);
    }

    void Update()
    {
        movement += speed * Time.deltaTime;
        transform.position += new Vector3(speed * Time.deltaTime,0,0);
    }
}
