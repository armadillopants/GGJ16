using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour 
{

	public float xMargin = 1f;
	public float yMargin = 1f;
	public float xSmooth = 8f;
	public float ySmooth = 8f;

	public Vector2 minXAndY;
	public Vector2 maxXAndY;

	private Transform target;

	// Use this for initialization
	void Start () 
	{
		target = GameObject.FindGameObjectWithTag("Player").transform;
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		TrackPlayer();
	}

	bool CheckXMargin()
	{
		return Mathf.Abs(transform.position.x - target.position.x) > xMargin;
	}

	bool CheckYMargin()
	{
		return Mathf.Abs(transform.position.y - target.position.y) > yMargin;
	}

	void TrackPlayer()
	{
		float targetX = target.position.x;
		float targetY = target.position.y;

		if(CheckXMargin())
		{
			targetX = Mathf.Lerp(transform.position.x, target.position.x, xSmooth * Time.deltaTime);
		}
			
		targetY = Mathf.Lerp(transform.position.y, target.position.y+2.5f, ySmooth * Time.deltaTime);

		targetX = Mathf.Clamp(targetX, minXAndY.x, maxXAndY.x);
		targetY = Mathf.Clamp(targetY, minXAndY.y, maxXAndY.y);

		transform.position = new Vector3(targetX, targetY, transform.position.z);
	}
}
