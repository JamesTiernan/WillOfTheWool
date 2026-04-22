using UnityEngine;

public class enemyCrab : MonoBehaviour
{
    Animator animator; 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
        Idle();
    }

    void Idle()
    {
        Invoke("Dive",3);
    }

    void Dive()
    {
        animator.SetTrigger("Dive");
        Invoke("Attack",3);
    }
    void Attack()
    {
        animator.SetTrigger("Attack");
        Invoke("Idle",3);
    }
}
