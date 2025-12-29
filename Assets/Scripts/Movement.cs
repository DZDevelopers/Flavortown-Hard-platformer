using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float moveSpeed = 6f;
    [SerializeField] private float jumpForce = 12f;
    [SerializeField] private float climbSpeed = 4f;
    [SerializeField] private Transform GroundChecker;
    private bool isGrounded;
    private bool isClimbing;
    private int Dir = 1;
    private Rigidbody2D rb;
    public InputSystem_Actions actions;
    private float move;
    private float climb;
     void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        actions = new InputSystem_Actions();
    }
    void OnEnable()
    {
        actions.Player.Enable();
        actions.Player.Move.performed += Movement;
        actions.Player.Jump.performed += Jumping;
        actions.Player.Move.canceled += Movement;
        actions.Player.Jump.canceled += Jumping;
    }
    void OnDisable()
    {
        actions.Player.Disable();
        actions.Player.Move.performed -= Movement;
        actions.Player.Jump.performed -= Jumping;
    }
    void Movement(InputAction.CallbackContext ctx)
    {
        move = ctx.ReadValue<Vector2>().x;
        climb = ctx.ReadValue<Vector2>().y;
    }
    void Jumping(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            if (isGrounded)
            {
                rb.linearVelocityY = jumpForce;
            }
        }
    }

    // Update is called once per frame   kkkkkk
    void Update()
    {
        if (move > 0)
        {
            Dir = 1;
        }
        if (move < 0)
        {
            Dir = -1;
        }
        if (move == 0)
        {
            Dir = Dir * 1;
        }
        if (isClimbing)
        {
            rb.linearVelocityY = climbSpeed * climb;
        }
        rb.linearVelocityX = moveSpeed * move;
        transform.localScale = new Vector2(Math.Abs(transform.localScale.x) * Dir, transform.localScale.y); 
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = false;
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ladder")
        {
            isClimbing = true;
            rb.gravityScale =0;
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ladder")
        {
            isClimbing = false;
            rb.gravityScale =1;
        }
    }
}