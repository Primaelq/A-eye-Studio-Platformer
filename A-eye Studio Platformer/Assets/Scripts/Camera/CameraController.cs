using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{
    public Transform player;
    public Vector2 margin;
    public Vector2 smoothing;
    public BoxCollider2D worldLimit;
    public bool isFollowing { get; set; }
    public Camera mainCamera;

    private Vector3 min;
    private Vector3 max;


    void Start ()
    {
        min = worldLimit.bounds.min;
        max = worldLimit.bounds.max;
        isFollowing = true;
	}
	
	void Update ()
    {
        var x = transform.position.x;
        var y = transform.position.y;

        if (isFollowing)
        {
            if (Mathf.Abs(x - player.position.x) > margin.x)
            {
                x = Mathf.Lerp(x, player.position.x, smoothing.x * Time.deltaTime);
            }

            if (Mathf.Abs(y - player.position.y) > margin.y)
            {
                y = Mathf.Lerp(y, player.position.y, smoothing.y * Time.deltaTime);
            }

            var cameraHalfWidth = mainCamera.orthographicSize * ((float)Screen.width / Screen.height);

            x = Mathf.Clamp(x, min.x + cameraHalfWidth, max.x - cameraHalfWidth);
            y = Mathf.Clamp(y, min.y + mainCamera.orthographicSize, max.y - mainCamera.orthographicSize);

            transform.position = new Vector3(x, transform.position.y, transform.position.z);
        }
	}
}
