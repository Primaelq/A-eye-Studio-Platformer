using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public static int health;
    public float speed = 10.0f, jumpForce = 10.0f;
    public LayerMask playerLayerMask, enemiesDetectorMask;

    Transform playerTransform, groundDetector, enemiesDetector0, enemiesDetector1, enemiesDetector2;
    Rigidbody2D playerRgb;
    PlayerAnimatorController playerAnimator;

    bool isGrounded = true;
    float horizontalInput = 0.0f;

    [HideInInspector]
    public static bool hitting = false;

	void Start ()
	{
        playerRgb = this.GetComponent<Rigidbody2D>();
        playerTransform = this.transform;
        groundDetector = GameObject.Find(this.name + "/GroundDetector").transform;
        enemiesDetector0 = GameObject.Find(this.name + "/EnemiesDetector0").transform;
        enemiesDetector1 = GameObject.Find(this.name + "/EnemiesDetector1").transform;
        enemiesDetector2 = GameObject.Find(this.name + "/EnemiesDetector2").transform;
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

        if (Physics2D.Linecast(playerTransform.position, enemiesDetector0.position, enemiesDetectorMask) == true
            || Physics2D.Linecast(playerTransform.position, enemiesDetector1.position, enemiesDetectorMask) == true
              || Physics2D.Linecast(playerTransform.position, enemiesDetector2.position, enemiesDetectorMask) == true)
        {
            hitting = true;
        }
        else
        {
            hitting = false;
        }

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
