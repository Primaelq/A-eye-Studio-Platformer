using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public static int health;
    public float speed = 10.0f, jumpForce = 10.0f;
    public LayerMask playerLayerMask;

    Transform playerTransform, groundDetector;
    Rigidbody2D playerRgb;
    PlayerAnimatorController playerAnimator;

    bool isGrounded = true;
    float horizontalInput = 0.0f;

	void Start ()
	{
        playerRgb = this.GetComponent<Rigidbody2D>();
        playerTransform = this.transform;
        groundDetector = GameObject.Find(this.name + "/GroundDetector").transform;
        playerAnimator = PlayerAnimatorController.instance;
        health = 6;
	}

	void Update ()
	{

    }

    void FixedUpdate ()
    {
        if (playerRgb.velocity.y != 0.0f)
            isGrounded = Physics2D.Linecast(playerTransform.position, groundDetector.position, playerLayerMask);

        playerAnimator.IsGrounded(isGrounded);

        #if !UNITY_ANDROID && !UNITY_IPHONE && !UNITY_BLACKBERRY && !UNITY_WINRT || UNITY_EDITOR

        horizontalInput = Input.GetAxisRaw("Horizontal");
            playerAnimator.UpdateSpeed(horizontalInput);
            if (Input.GetButtonDown("Jump"))
                Jump();

        #endif

        Move(horizontalInput);
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
        playerAnimator.UpdateSpeed(horizontalInput);
    }
}
