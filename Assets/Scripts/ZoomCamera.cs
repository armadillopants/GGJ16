using UnityEngine;
using System.Collections;

[RequireComponent(typeof(BoxCollider2D))]
public class ZoomCamera : MonoBehaviour 
{
	private float curZoom;
	private float minZoom = 5f;
	private float maxZoom = 12f;

	private bool canZoom = true;

	public float zoomTime = 5f;

	void Start () 
	{
		curZoom = minZoom;
	}

	void OnTriggerEnter2D()
	{
		StartCoroutine(CameraZoom());
	}

	IEnumerator CameraZoom()
	{
		GameObject camObject = GameObject.FindGameObjectWithTag("MainCamera");
		Camera cam = camObject.GetComponent<Camera>();

		if(curZoom < maxZoom)
		{
			curZoom = Mathf.Lerp(curZoom, maxZoom, zoomTime * Time.deltaTime);
			cam.orthographicSize = curZoom;
			yield return null;
		}
		else
		{
			
		}
	}
}
