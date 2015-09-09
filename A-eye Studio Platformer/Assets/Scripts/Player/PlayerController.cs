using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{

    public float speed = 10.0f, jumpForce = 10.0f;
    public LayerMask playerLayerMask;

    Transform playerTransform, groundDetector;
    Rigidbody2D playerRgb;

    bool isGrounded = false;
    float horizontalInput = 0.0f;

	void Start ()
	{
        playerRgb = this.GetComponent<Rigidbody2D>();
        playerTransform = this.transform;
        groundDetector = GameObject.Find(this.name + "/GroundDetector").transform;
	}

	void Update ()
	{
        
    }

    void FixedUpdate ()
    {
        isGrounded = Physics2D.Linecast(playerTransform.position, groundDetector.position, playerLayerMask);

        #if !UNITY_ANDROID && !UNITY_IPHONE && !UNITY_BLACKBERRY && !UNITY_WINRT

        Move(Input.GetAxisRaw ("Horizontal"));

        if (Input.GetButtonDown("Jump"))
            Jump();
        
        #else
            Move(horizontalInput);
        #endif

    }

    public void Move (float hInput)
    {
        Vector2 movementVel = playerRgb.velocity;
        movementVel.x = hInput * speed;
        playerRgb.velocity = movementVel;
    }

    public void Jump()
    {
        if (isGrounded)
            playerRgb.velocity += jumpForce * Vector2.up;
    }

    public void StartMoving (float hInput)
    {
        horizontalInput = hInput;
    }
}
