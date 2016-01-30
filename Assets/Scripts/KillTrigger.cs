using UnityEngine;
using System.Collections;

public class KillTrigger : MonoBehaviour 
{
	public bool canKill = true;

	void OnCollisionEnter2D(Collision2D col)
	{
		if(canKill && col.gameObject.tag == "Player")
		{
			col.gameObject.GetComponent<Animator>().SetBool("Death", true);
			col.gameObject.GetComponent<Rigidbody2D>().Sleep();
			Debug.Log("Death!");
		}
	}
}
