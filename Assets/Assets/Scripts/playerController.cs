using System.Runtime.InteropServices.WindowsRuntime;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class playerController : MonoBehaviour
{
    [Header("References")]
    [SerializeField] Rigidbody2D rb;

    [Header("Movement")]
    [SerializeField] float speed;
    [SerializeField] float jumpPower;

    [Header("Grounding")]
    [SerializeField] LayerMask groundLayer;
    [SerializeField] Transform groundCheck;


    private float horizontal;
    private SpriteRenderer playerSprite;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
      DontDestroyOnLoad(gameObject);
      rb = GetComponent<Rigidbody2D>();
      playerSprite = GetComponent<SpriteRenderer>();
    }

    void FixedUpdate()
    {
        rb.linearVelocityX = horizontal * speed;
    }

    public void Move(InputAction.CallbackContext context)
    {
        horizontal = context.ReadValue<Vector2>().x;
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
}
