using UnityEngine;
using System.Collections;

public class SpringBoard : MonoBehaviour
{

    public Sprite springBoardDown;
    public Sprite springBoardUp;

    public float springForce = 12.0f;

    SpriteRenderer render;
    
	void Start ()
    {
        render = GetComponent<SpriteRenderer>();
	}
	
	void Update ()
    {
	    
	}

    void OnTriggerEnter2D (Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            render.sprite = springBoardDown;
            other.GetComponent<Rigidbody2D>().velocity += 0.0f * Vector2.up;
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            render.sprite = springBoardDown;
            other.GetComponent<Rigidbody2D>().velocity += springForce * Vector2.up;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            render.sprite = springBoardUp;
        }
    }
}
