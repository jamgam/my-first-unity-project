using UnityEngine;

public class Weapon : MonoBehaviour
{
    public float fireRate = 0f;
    public float effectSpawnRate = 10f;
    public float damage = 10f;
    public Transform firePoint;
    public LayerMask whatToHit;
    public Transform BulletTrailPrefab;

    float timeToFire = 0;
    float timeToSpawnEffect = 0;
    public float Damage = 10;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (fireRate == 0)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                Shoot();
            }
        }
        else
        {
            if (Input.GetButton("Fire1") && Time.time > timeToFire)
            {
                timeToFire = Time.time + 1 / fireRate;
                Shoot();
            }
        }
    }

    void Shoot()
    {
        Vector2 mousePosition = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
        Vector2 firePointPosition = new Vector2(firePoint.position.x, firePoint.position.y);
        RaycastHit2D hit = Physics2D.Raycast(firePointPosition, mousePosition - firePointPosition, 100, whatToHit);
        if (Time.time >= timeToSpawnEffect)
        {
            timeToSpawnEffect = Time.time + 1 / effectSpawnRate;
            Effect();
        }

        Debug.DrawLine(firePointPosition, (mousePosition - firePointPosition) * 100, Color.black);
        if (hit.collider != null)
        {
            // Debug.DrawLine(firePointPosition, hit.point, Color.green);
            // Debug.Log($"We hit {hit.collider.name} and did {damage} damage.");
        }
    }

    void Effect()
    {
        Instantiate(BulletTrailPrefab, firePoint.position, firePoint.rotation);
    }

}
