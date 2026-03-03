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

    void Hop()
    {
        animator.SetTrigger("Hop");
        //animator.ResetTrigger("Hop");
    }

    public void Move()
    {
        canMove = true;
        animator.Play("Idle",animator.GetLayerIndex("Base Layer"));
        int moveDist;
        Debug.Log($"My Rotation: {transform.localEulerAngles.y}");
        if(transform.localEulerAngles.y == 180){moveDist = -6;}else{moveDist = 6;}
        transform.position = new Vector2(transform.position.x + moveDist,transform.position.y);
        playerDetectMovement.enabled = true;
    }
}
