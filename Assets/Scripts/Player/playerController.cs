
using System.Runtime.InteropServices.WindowsRuntime;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using Unity.Mathematics;

public class playerController : MonoBehaviour
{
    [Header("References")]
    [SerializeField] Rigidbody2D rb;
    [SerializeField] Animator animator;
    [SerializeField] itemWheelController itemWheelGUI;
    Camera mainCamera;

    [Header("Graphics")]
    [SerializeField] GameObject playerRig;

    [Header("Movement")]
    [SerializeField] private LayerMask groundMask;
    [SerializeField] float speed;
    [SerializeField] float jumpPower;

    [Header("Grounding")]
    [SerializeField] LayerMask groundLayer;
    [SerializeField] Transform groundCheck;

    [Header("Wool")]
    [SerializeField] GameObject woolPrefab;
    [SerializeField] GameObject heldWool;
    [SerializeField] Sprite noWool;
    [SerializeField] public lastCheckpoint checkpointManager;

    getStuck stuck;
    Vector3 mouseWorldPosition;
    Vector3 mouseRelativePosition;
    private healthManager healthManager;
    public bool flipped = false;
    public bool stunned;
    public bool invincible;
    bool isThrowing;
    float jumpTimer;
    bool moving;
    private float horizontal;
    private SpriteRenderer playerSprite;

    // Trajectory
    [Header("Trajectory")]
    [SerializeField] LineRenderer lineRenderer;
    [SerializeField] int linePoints = 175;
    [SerializeField] float timeBetweenPoints = 0.01f;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
      DontDestroyOnLoad(gameObject);
      healthManager = GetComponent<healthManager>();
      mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
      rb = GetComponent<Rigidbody2D>();
      playerSprite = GetComponent<SpriteRenderer>();
      animator = GetComponent<Animator>();
      stuck = GetComponent<getStuck>();
      heldWool.GetComponent<SpriteRenderer>().sprite = noWool;
    }

    void Update()
    {
        if (Mouse.current != null)
        {
            Vector3 mousePos = Mouse.current.position.ReadValue(); 
            mousePos.z = 6;
            mouseWorldPosition = mainCamera.ScreenToWorldPoint(mousePos);
            mouseRelativePosition =  (Vector2)mouseWorldPosition - (Vector2)gameObject.transform.position;

            if(lineRenderer != null)
            {
                if(isThrowing)
                {
                    DrawTrajectory();
                    lineRenderer.enabled = true;
                }
                else
                {
                    lineRenderer.enabled = false;
                }
            }
            //Debug.Log($"World Position: {mouseWorldPosition}");
        }

    }

    public void Footstep()
    {
        GameObject GroundStep = null;
        Collider2D coll = Physics2D.OverlapCapsule(groundCheck.position,new Vector2(0.8f,0.1f),CapsuleDirection2D.Horizontal,0,groundLayer);
        if(coll != null)
        {
            GroundStep = coll.gameObject;
        }
        if(GroundStep == null)
        {
            return;
        }
        if(IsGrounded())
        {
            if(GroundStep.CompareTag("footstepGrass"))
            {
                GetComponent<SFXPlayer>().PlaySound(0,0.2f);
            }
            else if(GroundStep.CompareTag("footstepDirt"))
            {
                GetComponent<SFXPlayer>().PlaySound(1,0.2f);
            }
            else if(GroundStep.CompareTag("footstepMetal"))
            {
                GetComponent<SFXPlayer>().PlaySound(2,0.2f);
            }
            else if(GroundStep.CompareTag("footstepRock"))
            {
                GetComponent<SFXPlayer>().PlaySound(3,0.2f);
            }
            else if(GroundStep.CompareTag("footstepSand"))
            {
                GetComponent<SFXPlayer>().PlaySound(4,0.2f);
            }
            else
            {
                GetComponent<SFXPlayer>().PlaySound(3,0.2f);
            }
        }
    }
    void FixedUpdate()
    {
        //Debug.Log($"Jump Timer : {jumpTimer}");
        if(IsGrounded())
        {
            jumpTimer = 1;
            animator.SetBool("onGround?",true);
            animator.SetBool("isJumping",false);
        }
        else
        {
        animator.SetBool("onGround?",false);
        if(jumpTimer > 0){jumpTimer -= 5 * Time.deltaTime;}
        
        }
        animator.SetFloat("yVelocity",rb.linearVelocityY);

        if(!stunned)
        {
            if(IsGrounded())
            {
                rb.linearVelocityY = -1f;
                if (!GetComponent<conveyorEffect>().onConveyor)
                {
                    rb.linearVelocityX *= 0.4f;
                }
            }
            else
            {
                rb.linearVelocityX *= 0.6f;
            }
            
            if(moving)
            {
                rb.linearVelocityX = horizontal * speed;
                
                

            }

            bool check = Physics2D.OverlapCircle(new Vector2(transform.position.x + 0.6f,transform.position.y + 0.5f),.5f,0,groundMask);
            Debug.Log($"CHECKECH: {check}");
            
            if(check){
                animator.SetBool("push",true);
            }
            else{
                animator.SetBool("push",false);
            }
            //animator.SetBool("push",false);
        
            if(stuck.isStuck)
            {
                rb.linearVelocityX *= .4f;
            }
        }
    }

    void OnDrawGizmosSelected()
    {

        Gizmos.DrawWireSphere(new Vector3(transform.position.x + 0.5f,transform.position.y + 0.5f,0f),0.5f);
    }

    public void Move(InputAction.CallbackContext context)
    {
        if(stunned){horizontal = 0;}
        else
        {
            horizontal = context.ReadValue<Vector2>().x;
            if(horizontal != 0){moving = true;}else{moving = false;}
            if(horizontal > 0 && horizontal != 0)
            {
                flipped = false;
                transform.localScale = new Vector3(1f, 1f, 1f);
            }
            else{if(horizontal < 0 && horizontal != 0){transform.localScale = new Vector3(-1f, 1f, 1f);flipped = true;}}
            animator.SetFloat("xVelocity",Mathf.Abs(horizontal));
        }
    }

    public void Jump(InputAction.CallbackContext context)
    {
        //if(isThrowing){return;}
        if(stunned){return;}
        if(context.performed && jumpTimer > 0 || stuck.isStuck)
        {
            jumpTimer = 0;
            animator.SetBool("isJumping",true);
            rb.linearVelocityY = jumpPower;
            gameObject.transform.position += Vector3.up * .1f;
            GetComponent<SFXPlayer>().PlaySound(5,0.1f);
        }
    }

    public void LandJump()
    {
        Footstep();
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCapsule(groundCheck.position,new Vector2(0.8f,0.1f),CapsuleDirection2D.Horizontal,0,groundLayer);
    }

    public void HitKnockback()
    {
        stunned = true;
        invincible = true;
        animator.Play("playerDamage");
    }


    private void KnockbackCooldown()
    {
        stunned = false;
        Invoke(nameof(IFrameOver),3f);
    }

    private void IFrameOver()
    {
        invincible = false;
    }

    public void throwWool()
    {
        Sprite mySprite = heldWool.GetComponent<SpriteRenderer>().sprite;
        if(!GetComponent<woolInventoryManager>().HasWool(mySprite))
        {
            heldWool.GetComponent<SpriteRenderer>().sprite = noWool;
            return;
        }
        GetComponent<woolInventoryManager>().LoseWool(mySprite);
        GameObject newObj = Instantiate(woolPrefab);
        newObj.transform.position = heldWool.transform.position;
        newObj.GetComponent<SpriteRenderer>().sprite = heldWool.GetComponent<SpriteRenderer>().sprite;
        if(!GetComponent<woolInventoryManager>().HasWool(mySprite))
        {
            heldWool.GetComponent<SpriteRenderer>().sprite = noWool;
        }
        newObj.GetComponent<Rigidbody2D>().linearVelocity = mouseRelativePosition.normalized * 10; 
    }

    void DrawTrajectory()
    {
        Vector3 origin = heldWool.transform.position;
        Vector3 startVelocity = mouseRelativePosition.normalized * 10;
        lineRenderer.positionCount = linePoints;
        float time = 0;
        for (int i = 0;i<linePoints;i++)
        {
            var x = (startVelocity.x * time) + (Physics2D.gravity.x / 2 * time * time);
            var y = (startVelocity.y * time) + (Physics2D.gravity.y / 2 * time * time);
            Vector3 point = new Vector3(x,y,0);
            lineRenderer.SetPosition(i,origin + point);
            time += timeBetweenPoints;
        }
    }


    
    public void ThrowStart()
    {
        if(stunned){return;}
        if(itemWheelGUI.itemWheelSelected == true){return;}
        if(heldWool.GetComponent<SpriteRenderer>().sprite == noWool){return;}
        else
        {
            isThrowing = true;
            animator.SetBool("thrown",false);
            animator.Play("playerGrabWool");
        }
    }

    public void ThrowComplete()
    {
        if(stunned){return;}
        if(itemWheelGUI.itemWheelSelected == true){return;}
        if(heldWool.GetComponent<SpriteRenderer>().sprite == noWool){return;}
        if(isThrowing)
        {
            isThrowing=false;
            animator.SetBool("thrown",true);
        }
    }
}
