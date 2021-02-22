using UnityEngine;

public class Bounds : MonoBehaviour
{
    public CompositeCollider2D platformCollider2D;
    public CompositeCollider2D myCollider2D;
    public BoxCollider2D myBoxCollider2D;
    public float yPadding = 10f;
    // Start is called before the first frame update
    void Start()
    {
        // myBoxCollider2D.size.Set(platformCollider2D.bounds.size.x, platformCollider2D.bounds.size.y + yPadding);
        myBoxCollider2D.size = new Vector2(platformCollider2D.bounds.size.x, platformCollider2D.bounds.size.y + yPadding);
        myBoxCollider2D.offset = new Vector2(platformCollider2D.bounds.center.x, platformCollider2D.bounds.center.y + yPadding / 2);
    }
}
