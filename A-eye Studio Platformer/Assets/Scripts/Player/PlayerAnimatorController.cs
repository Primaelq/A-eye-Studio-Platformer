using UnityEngine;
using System.Collections;

public class PlayerAnimatorController : MonoBehaviour
{

    public static PlayerAnimatorController instance;

    Transform playerTransform;
    Animator playerAnimator;
    Vector3 playerScale;

	void Start ()
    {
        playerTransform = this.transform;
        playerAnimator = this.gameObject.GetComponent<Animator>();
        instance = this;

        playerScale = playerTransform.localScale;
	}
	
	public void UpdateSpeed (float currentSpeed)
    {
        playerAnimator.SetFloat("Speed", currentSpeed);
        Flip(currentSpeed);
	}

    public void IsGrounded (bool isGrounded)
    {
        playerAnimator.SetBool("IsGrounded", isGrounded);
    }

    void Flip (float currentSpeed)
    {
        if ((currentSpeed < 0.0f && playerScale.x == 1.0f) || (currentSpeed > 0.0f && playerScale.x == -1))
        {
            playerScale.x *= -1;
            playerTransform.localScale = playerScale;
        }
    }
}
