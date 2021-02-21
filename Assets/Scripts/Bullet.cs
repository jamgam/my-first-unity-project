using UnityEngine;

public class Bullet : MonoBehaviour
{
  public float bulletSpeed = 15f;
  public float bulletDamage = 10f;
  public Rigidbody2D rb;

  // Update is called once per frame
  void FixedUpdate()
  {
    rb.velocity = transform.right * bulletSpeed;
  }

  void OnCollisionEnter2D(Collision2D collision)
  {
    Destroy(gameObject);
  }
}
