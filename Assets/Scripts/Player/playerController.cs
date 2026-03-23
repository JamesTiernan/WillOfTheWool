
using System.Runtime.InteropServices.WindowsRuntime;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

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
    Vector2 mouseWorldPosition;
    Vector2 mouseRelativePosition;
    private healthManager healthManager;
    public bool flipped = false;
    public bool stunned;
    public bool invincible;
    bool isThrowing;
    float jumpTimer;
    bool moving;
    private float horizontal;
    private SpriteRenderer playerSprite;
    
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
            Vector2 screenPosition = Mouse.current.position.ReadValue();
            mouseWorldPosition = mainCamera.ScreenToWorldPoint(screenPosition);
            mouseRelativePosition =  (Vector2)mouseWorldPosition - (Vector2)gameObject.transform.position;
            //Debug.Log($"World Position: {mouseWorldPosition}");
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
                rb.linearVelocityX *= 0.4f;
            }
            else
            {
                rb.linearVelocityX *= 0.6f;
            }
            
            if(moving)
            {
                rb.linearVelocityX = horizontal * speed;
            }
            if(stuck.isStuck){rb.linearVelocityX *= .4f;}
        }
    }

    public void Move(InputAction.CallbackContext context)
    {
        if(stunned || isThrowing){horizontal = 0;}
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
        if(isThrowing){return;}
        if(stunned){return;}
        if(context.performed && jumpTimer > 0 || stuck.isStuck)
        {
            jumpTimer = 0;
            animator.SetBool("isJumping",true);
            rb.linearVelocityY = jumpPower;
            gameObject.transform.position += Vector3.up * .1f;
        }
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
