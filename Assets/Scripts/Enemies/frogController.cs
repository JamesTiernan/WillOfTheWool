using UnityEngine;

public class frogController : MonoBehaviour
{
    [SerializeField] LayerMask playerLayer;
    Animator animator;
    [SerializeField] playerCheck playerDetectAttack;
    [SerializeField] playerCheck playerDetectMovement;
    bool canMove;
    int hops;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        canMove = true;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(playerDetectMovement.playerDetected && canMove)
        {
            canMove = false;
            Hop();
            playerDetectMovement.enabled = false;
            playerDetectMovement.playerDetected = false;
            Debug.Log("hop !");
        }
        animator.SetBool("Attack",playerDetectAttack.playerDetected);
        
    }

    void Hop()
    {
        animator.SetTrigger("Hop");
    }

    public void Move()
    {
        hops += 1;
        animator.Play("Idle",animator.GetLayerIndex("Base Layer"));
        Debug.Log($"{transform.localEulerAngles.y} // {hops}");
        if(transform.localEulerAngles.y == 180)
        {
            transform.position = new Vector2(transform.position.x - 6,transform.position.y);
        }
        else
        {
            transform.position = new Vector2(transform.position.x + 6,transform.position.y);
        }
        playerDetectMovement.enabled = true;
        if(hops == 2)
        {
            if(transform.localEulerAngles.y == 0)
            {
                Debug.Log("FLIP");
                transform.rotation = Quaternion.Euler(0,180,0);
            }
            else if(transform.localEulerAngles.y == 180)
            {
                Debug.Log("FLIP");
                transform.rotation = Quaternion.Euler(0,0,0);
            }
            hops = 0;
        }
        canMove = true;
    }
}
