using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed;
    public float jumpForce = 20f;
    public Rigidbody2D rb;
    public LayerMask groundLayers;
    public Animator anim;
    public Transform playerGraphics;
    public CircleCollider2D playerCircleCollider2D;
    [HideInInspector] public bool isFacingRight = true;

    float mx;
    private int airJumps = 1;

    // Update is called once per frame
    void Update()
    {
        mx = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump") && airJumps > 0)
        {
            Jump();
        }

        if (Mathf.Abs(mx) > 0.05f)
        {
            anim.SetBool("isRunning", true);
        }
        else
        {
            anim.SetBool("isRunning", false);
        }

        if (mx > 0.05f)
        {
            playerGraphics.localScale = new Vector3(1f, 1f, 1f);
            isFacingRight = true;
        }
        else if (mx < 0f)
        {
            playerGraphics.localScale = new Vector3(-1f, 1f, 1f);
            isFacingRight = false;
        }

        anim.SetBool("isGrounded", IsGround());
    }

    void FixedUpdate()
    {
        Vector2 movement = new Vector2(mx * movementSpeed, rb.velocity.y);

        // rb.velocity = movement;
    }

    void Jump()
    {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - gameObject.GetComponent<Transform>().position;

        difference.Set(difference.x, difference.y, 0f);
        difference.Normalize();
        difference *= jumpForce;

        rb.velocity = new Vector2(difference.x, difference.y);
        airJumps--;
    }

    public bool IsGround()
    {
        float extraGroundCheckDistance = 0.2f;

        RaycastHit2D raycastHit2D = Physics2D.CircleCast(playerCircleCollider2D.bounds.center, playerCircleCollider2D.radius, Vector2.down, extraGroundCheckDistance, groundLayers);

        if (raycastHit2D.collider != null)
        {
            airJumps = 1;
            return true;
        }
        return false;
    }
}
