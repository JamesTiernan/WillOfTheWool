using UnityEngine;
using System.Collections;
using System;

public class enemyCrab : MonoBehaviour
{
    [SerializeField] float random = 1;
    Animator animator; 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();

        Invoke("Idle",random);
    }

    void Idle()
    {
        Invoke("Dive",UnityEngine.Random.Range(2,4));
    }

    void Dive()
    {
        animator.SetTrigger("Dive");
        Invoke("Attack",UnityEngine.Random.Range(5,12));
    }
    void Attack()
    {
        animator.SetTrigger("Attack");
        Invoke("Idle",3);
    }

    public void SFXAttack()
    {
        GetComponent<SFXPlayer>().PlaySound(0,0.1f);
    }
}
