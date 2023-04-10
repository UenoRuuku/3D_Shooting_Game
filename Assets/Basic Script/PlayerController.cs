using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float _rotateSpeed;
    private Rigidbody rb;
    public Camera cam;

    Vector3 movement;
    Vector3 mousePos;
    private void Start()
    {
        rb = this.GetComponent<Rigidbody>();
    }
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");


        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + (Vector3)movement * moveSpeed * Time.fixedDeltaTime);

        Vector3 lookDir = mousePos - (Vector3)rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = Quaternion.Euler(0,angle,0);
    }
}
