using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
  public float movementSpeed;
  public Rigidbody2D rb;

  public float jumpForce = 20f;
  public Transform feet;
  public LayerMask groundLayers;

  public Animator anim;

  [HideInInspector] public bool isFacingRight = true;

  float mx;

  // Update is called once per frame
  void Update()
  {
    mx = Input.GetAxisRaw("Horizontal");

    if (Input.GetButtonDown("Jump") && IsGround())
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
      transform.localScale = new Vector3(1f, 1f, 1f);
      isFacingRight = true;
    }
    else if (mx < 0f)
    {
      transform.localScale = new Vector3(-1f, 1f, 1f);
      isFacingRight = false;
    }

    anim.SetBool("isGrounded", IsGround());
  }

  void FixedUpdate()
  {
    Vector2 movement = new Vector2(mx * movementSpeed, rb.velocity.y);

    rb.velocity = movement;
  }

  void Jump()
  {
    Vector2 movement = new Vector2(rb.velocity.x, jumpForce);

    rb.velocity = movement;
  }

  public bool IsGround()
  {
    Collider2D groundCheck = Physics2D.OverlapCircle(feet.position, 0.5f, groundLayers);

    if (groundCheck != null)
    {
      return true;
    }
    return false;

  }
}
