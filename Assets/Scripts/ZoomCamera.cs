using UnityEngine;
using System.Collections;

[RequireComponent(typeof(BoxCollider2D))]
public class ZoomCamera : MonoBehaviour 
{
	private float originalPos;
	private float maxZoom = 12f;

	private bool canZoom = false;

	public float zoomTime = 5f;

	private float lastZoom;

	Camera cam;

	void Start () 
	{
		GameObject camObject = GameObject.FindGameObjectWithTag("MainCamera");
		cam = camObject.GetComponent<Camera>();

		originalPos = cam.orthographicSize;
		lastZoom = originalPos;
	}

	void Update()
	{
		if(canZoom)
		{
			if(lastZoom == minZoom)
			{
				curZoom = Mathf.Lerp(curZoom, maxZoom, zoomTime * Time.deltaTime);
				cam.orthographicSize = curZoom;

				if(curZoom == maxZoom)
				{
					cam.orthographicSize = maxZoom;
					lastZoom = maxZoom;
				}
			}
			else if(lastZoom == maxZoom)
			{
				curZoom = Mathf.Lerp(curZoom, minZoom, zoomTime * Time.deltaTime);
				cam.orthographicSize = curZoom;

				if(minZoom - curZoom < Mathf.Epsilon)
				{
					cam.orthographicSize = minZoom;
					lastZoom = minZoom;
				}
			}
		}
	}


	void OnTriggerEnter2D()
	{
		if(lastZoom == originalPos)
		{
			StartCoroutine(ZoomOut());
		}
		else if(lastZoom == maxZoom)
		{
		}
	}

	IEnumerator ZoomOut()
	{
		
	}
}
