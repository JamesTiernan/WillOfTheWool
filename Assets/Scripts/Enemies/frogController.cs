using UnityEngine;

public class frogController : MonoBehaviour
{
    [SerializeField] LayerMask playerLayer;
    Animator animator;
    [SerializeField] playerCheck playerDetectAttack;
    [SerializeField] playerCheck playerDetectMovement;
    bool canMove;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        canMove = true;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(playerDetectAttack.playerDetected)
        {
            animator.SetTrigger("Attack");
        }
        if(playerDetectMovement.playerDetected && canMove)
        {
            canMove = false;
            Hop();
            playerDetectMovement.enabled = false;
            playerDetectMovement.playerDetected = false;
            Debug.Log("hop !");
        }
    }

    /*public void Damage()
    {
        Collider2D other = Physics2D.OverlapCircle(attackPoint.position,5,playerLayer);
        if(other != null)
        {
            other.GetComponent<healthManager>().Damage(3,true);
            playerController checkPlayer = other.GetComponent<playerController>();
            if(checkPlayer != null){other.GetComponent<playerController>().HitKnockback();}
        }
    }*/

    void Hop()
    {
        animator.SetTrigger("Hop");
        //animator.ResetTrigger("Hop");
    }

    public void Move()
    {
        canMove = true;
        animator.Play("Idle",animator.GetLayerIndex("Base Layer"));
        transform.position = new Vector2(transform.position.x + 6,transform.position.y);
        playerDetectMovement.enabled = true;
    }
}
