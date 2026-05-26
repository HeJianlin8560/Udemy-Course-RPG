using UnityEngine;


public class player : MonoBehaviour
{

    private Rigidbody2D rb;
    private Animator anim;
    [Header("Movement details")]
    [SerializeField] private float moveSeepd = 3.5f;
    [SerializeField] private float jumpFore = 8;
    [SerializeField] private bool isFacingRight = true;
    private float xInput;

    [Header("Collision details")]
    [SerializeField] private float groundCheckDistance ;
    [SerializeField] private bool isGrounded;
    [SerializeField] private LayerMask whatIsGround;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        HandleCollsion();
        HandleInput();
        HandleMovement();
        HandleAnimations();
     }
   
    void Jump() {
        if (isGrounded)
        {
            bool isJumping = rb.linearVelocity.y != 0;
            anim.SetBool("isJumping", isJumping);
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpFore);
        }
    }
    /*[ContextMenu("Filp")]/*/
    void Filp() {

        isFacingRight = !isFacingRight;

        Vector3 currentScale = transform.localScale;

        currentScale.x *= -1;

        transform.localScale = currentScale;
    }
    void HandleAnimations()
    {
        bool isMoving = rb.linearVelocity.x != 0;
        anim.SetBool("isMoving", isMoving);
    }
    private void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            Jump();
    }
    void HandleMovement()
    {

        xInput = Input.GetAxisRaw("Horizontal");
        if (xInput > 0 && !isFacingRight)
        {
            Filp();
        }
        else if (xInput < 0 && isFacingRight)
        {
            Filp();
        }
        rb.linearVelocity = new Vector2(xInput * moveSeepd, rb.linearVelocity.y);

    }
    private void HandleCollsion()
    {
        isGrounded = Physics2D.Raycast(transform.position, Vector2.down, groundCheckDistance,whatIsGround);
    }
    private void OnDrawGizmos() {
        Gizmos.DrawLine(transform.position,transform.position + new Vector3 (0,-groundCheckDistance));
    }
}
