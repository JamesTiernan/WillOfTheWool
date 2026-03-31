using UnityEngine;

public class flyaway : MonoBehaviour
{

    Animator animator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Is in range");
        if (other.CompareTag("Player"))
            fly();
    }

        private void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("Out of range");
    }

      void fly()
    {
        animator.SetTrigger("IsInRange");
    }
}
