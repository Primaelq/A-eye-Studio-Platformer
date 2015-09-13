using UnityEngine;
using System.Collections;

public class MapCamera : MonoBehaviour 
{
	public float speed = 0.1f;
	public BoxCollider2D worldLimit;
	public Camera MainCamera;

	public float min = -1.16f;
	public float max = 14.5f;
	

	void Update() 
	{

		if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved) 
		{
			Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;
			transform.Translate(-touchDeltaPosition.x * speed * Time.deltaTime, -touchDeltaPosition.y * 0, 0);
		}

		transform.position = new Vector3(Mathf.Clamp(transform.position.x, min, max), transform.position.y, transform.position.z);

	}
}