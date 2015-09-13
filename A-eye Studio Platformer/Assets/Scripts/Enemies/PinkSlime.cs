using UnityEngine;
using System.Collections;

public class PinkSlime : MonoBehaviour
{
    public float speed = 1.0f;
    public LayerMask enemyMask;
    Rigidbody2D slimeRgb;
    Transform slimeTransform;
    float slimeWidth, slimeHeight;

	void Start ()
    {
        slimeTransform = this.transform;
        slimeRgb = GetComponent<Rigidbody2D>();
        SpriteRenderer slimeSprite = this.GetComponent<SpriteRenderer>();
        slimeWidth = slimeSprite.bounds.extents.x;
        slimeHeight = slimeSprite.bounds.extents.y;
    }
	
	void FixedUpdate ()
    {
        Vector2 lineCastPos = slimeTransform.position.ToVector2() - slimeTransform.right.ToVector2() * slimeWidth + Vector2.up * slimeHeight;
        Debug.DrawLine(lineCastPos, lineCastPos + Vector2.down);
        bool isGrounded = Physics2D.Linecast(lineCastPos, lineCastPos + Vector2.down, enemyMask);
        Debug.DrawLine(lineCastPos, lineCastPos - slimeTransform.right.ToVector2() * 0.5f);
        bool isBlocked = Physics2D.Linecast(lineCastPos, lineCastPos - slimeTransform.right.ToVector2() * 0.05f, enemyMask);

        if (!isGrounded || isBlocked)
        {
            Vector3 currentRotation = slimeTransform.eulerAngles;
            currentRotation.y += 180.0f;
            slimeTransform.eulerAngles = currentRotation;
        }

        Vector2 slimeVel = slimeRgb.velocity;
        slimeVel.x = -slimeTransform.right.x * speed;
        slimeRgb.velocity = slimeVel;
	}
<<<<<<< HEAD

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            PlayerController.health -= 1;
        }
    }
=======
>>>>>>> origin/master
}
