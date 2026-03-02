using System.Runtime.InteropServices.WindowsRuntime;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

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
    getStuck stuck;
    Vector2 mouseWorldPosition;
    Vector2 mouseRelativePosition;
    private healthManager healthManager;
    private bool flipped = false;
    bool stunned;
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
        if(IsGrounded())
        {
            animator.SetBool("onGround?",true);
            animator.SetBool("isJumping",false);
        }
        else{animator.SetBool("onGround?",false);}
        animator.SetFloat("yVelocity",rb.linearVelocityY);

        if(IsGrounded())
        {
            rb.linearVelocityX *= 0.4f;
        }
        else
        {
            rb.linearVelocityX *= 0.95f;
        }
        
        if(!stunned && moving)
        {
            rb.linearVelocityX = horizontal * speed;
        }
        if(stuck.isStuck){rb.linearVelocityX *= .4f;}
    }

    public void Move(InputAction.CallbackContext context)
    {
        if(stunned){horizontal = 0;return;}
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

    public void Jump(InputAction.CallbackContext context)
    {
        if(stunned){return;}
        if(context.performed && IsGrounded() || stuck.isStuck)
        {
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
        if(flipped)
        {
            rb.linearVelocityX = 5f;
        }
        else{rb.linearVelocityX = -5f;}
        rb.linearVelocityY = 4f;
        Invoke(nameof(KnockbackCooldown),0.5f);
    }

    private void KnockbackCooldown()
    {
        stunned = false;
    }

    public void throwWool()
    {
        GameObject newObj = Instantiate(woolPrefab);
        newObj.transform.position = heldWool.transform.position;
        newObj.GetComponent<SpriteRenderer>().sprite = heldWool.GetComponent<SpriteRenderer>().sprite;
        heldWool.GetComponent<SpriteRenderer>().sprite = noWool;
        newObj.GetComponent<Rigidbody2D>().linearVelocity = mouseRelativePosition.normalized * 10;

        // ----- NEED TO DO RIGHT WOOL ------
        healthManager.Damage(1,false);

        /*
        if(mouseWorldPosition.x - gameObject.transform.position.x > 0)
        {
            newObj.GetComponent<Rigidbody2D>().linearVelocityX =  20;
        }
        else{newObj.GetComponent<Rigidbody2D>().linearVelocityX = -20;}*/
        
    }
    public void throwAnimationPlay()
    {
        if(stunned){return;}
        if(itemWheelGUI.itemWheelSelected == true){return;}
        if(heldWool.GetComponent<SpriteRenderer>().sprite == noWool){return;}
        animator.Play("playerThrowWool");
    }
}
