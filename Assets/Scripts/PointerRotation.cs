using UnityEngine;

public class PointerRotation : MonoBehaviour
{
    public Transform playerTransform;
    public SpriteRenderer playerSprite;
    public int rotationOffset = 0;
    // Start is called before the first frame update

    void Awake()
    {

    }
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - playerTransform.position;
        difference.Normalize();
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;

        Vector3 differenceXY = new Vector3(difference.x, difference.y, 0f);
        differenceXY.Normalize();
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ + rotationOffset);
        transform.position = playerTransform.position + differenceXY;
    }
}
