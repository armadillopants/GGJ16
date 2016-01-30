using UnityEngine;
using System.Collections;

public class DestroyObject : MonoBehaviour 
{
	public GameObject toDestroy;

	void OnTriggerEnter2D()
	{
		Destroy(toDestroy, 2f);
	}
}
