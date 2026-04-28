using System;
using UnityEngine;

public class EnemyDetect : MonoBehaviour
{
    [SerializeField] float t;
    private Animator animator;
    bool attacking = false;
    float attack = 0;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (attacking)
        {
            attack = Mathf.Lerp(attack, 1f, t * Time.deltaTime);
        }
        else
        {
            attack = Mathf.Lerp(attack, 0f, t * Time.deltaTime);
        }
        animator.SetFloat("Attack",attack);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        GetComponent<SFXPlayer>().PlaySound(0,.1f);
        Debug.Log("Is in range");
        if (other.CompareTag("Player"))
            attacking = true;
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("Out of range");
        if (other.CompareTag("Player"))
            attacking = false;
    }
}
