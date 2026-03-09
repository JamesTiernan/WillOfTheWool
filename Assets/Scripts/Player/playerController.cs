
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
    getStuck stuck;
    Vector2 mouseWorldPosition;
    Vector2 mouseRelativePosition;
    private healthManager healthManager;
    public bool flipped = false;
    public bool stunned;
    float jumpTimer;
    float lerpTime = 1f;
    float lerpDuration = 1f;
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
        if(stunned)
        {
            lerpTime += Time.deltaTime;
            // Calculate how far along we are in the color transition (from 0 to 1)
            float t = lerpTime / lerpDuration;

            // Lerp smoothly from startColor to endColor using the calculated value 't'
            playerSprite.color = Color.Lerp(Color.white, Color.red, t);
        }
        else
        {
            lerpTime += Time.deltaTime;
            // Calculate how far along we are in the color transition (from 0 to 1)
            float t = lerpTime / lerpDuration;

            // Lerp smoothly from startColor to endColor using the calculated value 't'
            playerSprite.color = Color.Lerp(Color.red, Color.white, t);
        }

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
        Debug.Log($"Jump Timer : {jumpTimer}");
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
        lerpTime = 0f;
        stunned = true;
        //playerSprite.color = Color.Lerp(playerSprite.color,Color.red,1f);
        /*
        if(flipped)
        {
            rb.linearVelocityX = 5f;
        }
        else{rb.linearVelocityX = -5f;}
        rb.linearVelocityY = 4f;
        */
        //GetComponent<SpriteRenderer>().color = new Color(241,140,140);
        animator.Play("playerDamage");
    }


    private void KnockbackCooldown()
    {
        lerpTime = 0f;
        //playerSprite.color = Color.Lerp(playerSprite.color,Color.white,1f);
        stunned = false;
    }

    public void throwWool()
    {
        Sprite mySprite = heldWool.GetComponent<SpriteRenderer>().sprite;
        GetComponent<woolInventoryManager>().LoseWool(mySprite);
        GameObject newObj = Instantiate(woolPrefab);
        newObj.transform.position = heldWool.transform.position;
        newObj.GetComponent<SpriteRenderer>().sprite = heldWool.GetComponent<SpriteRenderer>().sprite;
        heldWool.GetComponent<SpriteRenderer>().sprite = noWool;
        newObj.GetComponent<Rigidbody2D>().linearVelocity = mouseRelativePosition.normalized * 10; 
    }

    public void throwAnimationPlay()
    {
        if(stunned){return;}
        if(itemWheelGUI.itemWheelSelected == true){return;}
        if(heldWool.GetComponent<SpriteRenderer>().sprite == noWool){return;}
        animator.Play("playerThrowWool");
    }
}
