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
    Vector2 mouseWorldPosition;
    Vector2 mouseRelativePosition;

    private float horizontal;
    private SpriteRenderer playerSprite;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
      DontDestroyOnLoad(gameObject);
      mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
      rb = GetComponent<Rigidbody2D>();
      playerSprite = GetComponent<SpriteRenderer>();
      animator = GetComponent<Animator>();
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
        rb.linearVelocityX = horizontal * speed;
    }

    public void Move(InputAction.CallbackContext context)
    {
        horizontal = context.ReadValue<Vector2>().x;
        if(horizontal > 0 && horizontal != 0)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
        else{if(horizontal < 0 && horizontal != 0){transform.localScale = new Vector3(-1f, 1f, 1f);}}
        animator.SetFloat("xVelocity",Mathf.Abs(horizontal));
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if(context.performed && IsGrounded())
        {
            rb.linearVelocityY = jumpPower;
        }
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCapsule(groundCheck.position,new Vector2(0.8f,0.1f),CapsuleDirection2D.Horizontal,0,groundLayer);
    }

    public void throwWool()
    {
        GameObject newObj = Instantiate(woolPrefab);
        newObj.transform.position = heldWool.transform.position;
        newObj.GetComponent<SpriteRenderer>().sprite = heldWool.GetComponent<SpriteRenderer>().sprite;
        heldWool.GetComponent<SpriteRenderer>().sprite = noWool;
        newObj.GetComponent<Rigidbody2D>().linearVelocity = mouseRelativePosition.normalized * 10;

        /*
        if(mouseWorldPosition.x - gameObject.transform.position.x > 0)
        {
            newObj.GetComponent<Rigidbody2D>().linearVelocityX =  20;
        }
        else{newObj.GetComponent<Rigidbody2D>().linearVelocityX = -20;}*/
        
    }
    public void throwAnimationPlay()
    {
        if(itemWheelGUI.itemWheelSelected == true){return;}
        if(heldWool.GetComponent<SpriteRenderer>().sprite == noWool){return;}
        animator.Play("playerThrowWool");
    }
}
