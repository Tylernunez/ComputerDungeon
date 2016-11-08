using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public float speed = 6.0F;
    public float jumpHeight = 6.0F;
    private Rigidbody rb;
    private float distToGround;

    void Start()
    {
        Collider col = this.GetComponent<Collider>();
        distToGround = col.bounds.extents.y;
        Cursor.lockState = CursorLockMode.Locked;
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        float verticalMovement = Input.GetAxis("Vertical") * speed;
        float horizontalMovement = Input.GetAxis("Horizontal") * speed;
        verticalMovement *= Time.deltaTime;
        horizontalMovement *= Time.deltaTime;

        transform.Translate(horizontalMovement, 0, verticalMovement);

        if (Input.GetKeyDown("escape"))
            Cursor.lockState = CursorLockMode.None;
        if (Input.GetKeyDown("space") && IsGrounded())
            rb.AddForce(Vector3.up * jumpHeight);
    }

    bool IsGrounded() {
   return Physics.Raycast(transform.position, -Vector3.up, distToGround + 0.1f);
    }
}

