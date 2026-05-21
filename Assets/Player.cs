using UnityEngine;


public class player : MonoBehaviour
{

    private Rigidbody2D rb;
    private Animator anim;

    [SerializeField] private float moveSeepd = 3.5f;
    [SerializeField] private float jumpFore = 8;
    [SerializeField] private bool isFacingRight = true;
    private float xInput;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        HandleInput();
        HandleMovement();
        HandleAnimations();
    }
    private void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            Jump();
    }
    void Jump() {
        bool isJumping = rb.linearVelocity.y != 0;
        anim.SetBool("isJumping", isJumping); 
        rb.linearVelocity = new Vector2 (rb.linearVelocity.x,jumpFore);
    }

    void HandleMovement() {
      
        xInput = Input.GetAxisRaw("Horizontal");
        if (xInput > 0 && !isFacingRight)
        {
            Filp();
        }
        else if(xInput<0 && isFacingRight)
        {
            Filp();
        }
        rb.linearVelocity = new Vector2(xInput * moveSeepd, rb.linearVelocity.y);

    }

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
}
