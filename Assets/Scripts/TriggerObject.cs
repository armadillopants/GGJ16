using UnityEngine;
using System.Collections;

[RequireComponent(typeof(BoxCollider2D))]
public class TriggerObject : MonoBehaviour 
{
	private bool triggered = false;

	public virtual void OnTriggerEnter2D()
	{
		if(triggered)
		{
			return;
		}

		triggered = true;
	}
}
