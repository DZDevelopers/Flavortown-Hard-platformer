using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float moveSpeed = 6f;
    [SerializeField] private float jumpForce = 12f;
    [SerializeField] private float climbSpeed = 4f;
    private bool isGrounded;
    private bool isClimbing;
    private int Dir = 1;
    private Rigidbody2D rb;
    public InputSystem_Actions actions;
    private float move;
    private float climb;
    public GroundCheck GC;
    public Animator anime;
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
            anime.SetBool("IsWalking",true);
        }
        if (move < 0)
        {
            Dir = -1;
            anime.SetBool("IsWalking",true);
        }
        if (move == 0)
        {
            Dir = Dir * 1;
            anime.SetBool("IsWalking",false);
        }
        if (isClimbing)
        {
            rb.linearVelocityY = climbSpeed * climb;
        }
        if (GC.isGrounded)
        {
            isGrounded = true;
        }
        if (!GC.isGrounded)
        {
            isGrounded = false;
        }
    }
    void Death()
    {
        Destroy(gameObject);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    void FixedUpdate()
    {
        rb.linearVelocityX = moveSpeed * move;
        transform.localScale = new Vector2(Math.Abs(transform.localScale.x) * Dir, transform.localScale.y); 
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ladder")
        {
            isClimbing = true;
            rb.gravityScale =0;
        }
        if (collision.gameObject.tag == "Finish")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
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
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Trap")
        {
            Death();
        }
    }
}