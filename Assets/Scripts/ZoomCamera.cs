using UnityEngine;
using System.Collections;

[RequireComponent(typeof(BoxCollider2D))]
public class ZoomCamera : MonoBehaviour 
{
	private float originalPos;
	public float maxZoom = 12f;

	public float zoomDuration = 3f;

	Camera cam;
	private bool triggered = false;

	void Start () 
	{
		GameObject camObject = GameObject.FindGameObjectWithTag("MainCamera");
		cam = camObject.GetComponent<Camera>();

		originalPos = cam.orthographicSize;
	}

	void OnTriggerEnter2D()
	{
		if(triggered)
		{
			return;
		}

		if(cam.orthographicSize == originalPos)
		{
			StartCoroutine(ZoomOut());
		}
		else if(cam.orthographicSize == maxZoom)
		{
			StartCoroutine(ZoomIn());
		}

		triggered = true;
	}

	IEnumerator ZoomIn()
	{
		float delta = 0f;
		triggered = false;

		if(cam.orthographicSize <= maxZoom)
		{
			while(delta < zoomDuration)
			{
				delta += Time.deltaTime;
				yield return true;
				cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, originalPos, delta / zoomDuration);
			}
		}
	}

	IEnumerator ZoomOut()
	{
		float delta = 0f;
		triggered = false;

		while(delta < zoomDuration)
		{
			delta += Time.deltaTime;
			yield return true;
			cam.orthographicSize = Mathf.Lerp(originalPos, maxZoom, delta / zoomDuration);
		}
	}
}
