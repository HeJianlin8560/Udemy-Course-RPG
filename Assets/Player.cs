using UnityEngine;


public class player : MonoBehaviour
{

    private Rigidbody2D rb;

    [SerializeField] private float moveSeepd = 3.5f;
    [SerializeField] private float jumpFore = 8;
    private float xInput;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        HandleInput();
        HandleMovement();

    }
    private void HandleInput()
    {
        xInput = Input.GetAxisRaw("Horizontal");
        if (Input.GetKeyDown(KeyCode.Space))
            Jump();
    }
    void Jump() { 
            rb.linearVelocity = new Vector2 (rb.linearVelocity.x,jumpFore);
    }

    void HandleMovement() {
        rb.linearVelocity = new Vector2(xInput*moveSeepd, rb.linearVelocity.y); 
    }


}
